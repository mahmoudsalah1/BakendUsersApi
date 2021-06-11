using AutoMapper;
using BackendUsers.Models;
using BackendUsers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.BL.Mapper
{
    public class DomainProfile : Profile
    {
         public DomainProfile()
        {
         
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

        }
    }
}
