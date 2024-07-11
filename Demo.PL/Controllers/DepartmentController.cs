using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.PL.Models;
using DEMO.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {   private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(
           // IDepartmentRepository departmentRepository ,
           IUnitOfWork unitOfWork, IMapper mapper ,
            ILogger<DepartmentController> logger) {
        
          // _departmentRepository= departmentRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
           _mapper=mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentViewModels = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View(departmentViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new DepartmentViewModel());
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(departmentViewModel);
                _unitOfWork.DepartmentRepository.Add(department);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentViewModel);
        }

        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var department = _unitOfWork.DepartmentRepository.GetById(id);
                var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

                if (department == null)
                {
                    return NotFound();
                }

                return View(departmentViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var department = _unitOfWork.DepartmentRepository.GetById(id);
                var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

                if (department == null)
                {
                    return NotFound();
                }

                return View(departmentViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id, DepartmentViewModel departmentViewModel)
        {
            try
            {
                var department = _unitOfWork.DepartmentRepository.GetById(id);

                if (department == null)
                {
                    return NotFound();
                }

                _unitOfWork.DepartmentRepository.Delete(department);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var department = _unitOfWork.DepartmentRepository.GetById(id);
                var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

                if (department == null)
                {
                    return NotFound();
                }

                return View(departmentViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(DepartmentViewModel updatedDepartmentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingDepartment = _unitOfWork.DepartmentRepository.GetById(updatedDepartmentViewModel.Id);

                    if (existingDepartment == null)
                    {
                        return NotFound();
                    }

                    existingDepartment.Code = updatedDepartmentViewModel.Code;
                    existingDepartment.Name = updatedDepartmentViewModel.Name;

                    _unitOfWork.DepartmentRepository.Update(existingDepartment);
                    _unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }

                return View(updatedDepartmentViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }



        }
}
