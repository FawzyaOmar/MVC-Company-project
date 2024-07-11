using Demo.BLL.Interfaces;
using DEMO.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }


        public UnitOfWork(AppDbContext context)
           // IEmployeeRepository employeeRepository,
           //IDepartmentRepository departmentRepository) 
            {  
            
            _context = context; 
            EmployeeRepository=new EmployeeRepository(context);
            DepartmentRepository=new DepartmentRepository(context);

        }
        public int Complete() {

         return _context.SaveChanges();
        
        }

    }
}
