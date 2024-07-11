using AutoMapper;
using Demo.PL.Models;
using DEMO.DAL.Entities;

namespace Demo.PL.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() {
            // CreateMap<DepartmentProfile, Department>();
            // CreateMap<Department, DepartmentProfile>();

            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        
        
        }

       


    }
}
