using AutoMapper;
using EMS.Application.Features.Employee.Commands.AddEmployee;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee,AddEmployeeCommand>().ReverseMap();
        }
    }
}
