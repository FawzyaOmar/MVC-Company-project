using Demo.BLL.Interfaces;
using DEMO.DAL.Context;
using DEMO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee> ,IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
           _context=context;
        }

        public AppDbContext Context { get; }

        //public int Add(Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _context.Employees.Remove(employee);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAll()
        //=> _context.Employees.ToList();

        //public Employee GetById(int id)
        //{
        //    return _context.Employees.FirstOrDefault(x => x.Id==id);
        //}

        public IEnumerable<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Search(string name)
        {
            var result = _context.Employees.Where(employee=>employee.Name.Trim().ToLower().Contains(name.Trim().ToLower())
                                               ||employee.Email.Trim().ToLower().Contains(name.Trim().ToLower()));

            return result;
        
        }

        //public int Update(Employee employee)
        //{
        //    _context.Employees.Update(employee);
        //    return _context.SaveChanges();
        //}
    }
}
