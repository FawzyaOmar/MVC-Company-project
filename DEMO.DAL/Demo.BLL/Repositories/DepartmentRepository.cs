﻿using Demo.BLL.Interfaces;
using DEMO.DAL.Context;
using DEMO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepository :GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public AppDbContext Context { get; }

        //public int Add(Department department)
        //{
        //    _context.Departments.Add(department);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Department department)
        //{
        //    _context.Departments.Remove(department);
        //    return _context.SaveChanges();

        //}

        //public IEnumerable<Department> GetAll()
        //=> _context.Departments.ToList();

        //public Department GetById(int? id)
        //{
        //    return _context.Departments.FirstOrDefault(x => x.Id == id);
        //}

        //public int Update(Department department)
        //{
        //    _context.Departments.Update(department);
        //    return _context.SaveChanges();
        //}
    }
}
