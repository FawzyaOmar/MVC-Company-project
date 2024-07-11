using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.PL.Helper;
using Demo.PL.Models;
using DEMO.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
       

       
        public IActionResult Index(string SearchValue = "")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> employeesViewModel;

            if (string.IsNullOrEmpty(SearchValue))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll();
            }
            else
            {
                employees = _unitOfWork.EmployeeRepository.Search(SearchValue);
            }

            employeesViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return View(employeesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            // ModelState["Department"].ValidationState = ModelValidationState.Valid;
            //Manual Mapping
            //Employee employee = new Employee
            //{
            //    Email = employeeViewModel.Email,
            //    Name = employeeViewModel.Name,
            //    Salary = employeeViewModel.Salary,
            //    IsActive = employeeViewModel.IsActive,
            //    Address = employeeViewModel.Address,
            //    HireDate = employeeViewModel.HireDate,
            //    DepartmentId=employeeViewModel.DepartmentId,
            //};
            //Auto Mapper
            var employee = _mapper.Map<Employee>(employeeViewModel);

            employee.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Images");
            //var employee = mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);

            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepository.Add(employee);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(employeeViewModel);
        }


        [HttpGet]
public IActionResult Update()
{
    ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
    return View(new EmployeeViewModel());
}

[HttpPost]
public IActionResult Update(EmployeeViewModel employeeViewModel)
{
    //ModelState["Department"].ValidationState = ModelValidationState.Valid;
    if (ModelState.IsValid)
    {
        var employee = _mapper.Map<Employee>(employeeViewModel);
        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.Complete();
        return RedirectToAction(nameof(Index));
    }
    ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
    return View(employeeViewModel);
}

public IActionResult Details(int? id)
{
    try
    {
        if (id is null)
        {
            return BadRequest();
        }
        var employee = _unitOfWork.EmployeeRepository.GetById(id);
        if (employee is null)
            return NotFound();

        var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
        return View(employeeViewModel);
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
    if (id == null)
    {
        return BadRequest();
    }

    var employee = _unitOfWork.EmployeeRepository.GetById(id);

    if (employee == null)
    {
        return NotFound();
    }

    var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
    ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
    return View(employeeViewModel);
}

[HttpPost]
public IActionResult Delete(int id)
{
    var employee = _unitOfWork.EmployeeRepository.GetById(id);

    if (employee == null)
    {
        return NotFound();
    }

    _unitOfWork.EmployeeRepository.Delete(employee);
    _unitOfWork.Complete();

    return RedirectToAction(nameof(Index));
}






    }
}
