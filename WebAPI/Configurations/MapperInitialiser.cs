using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Configurations
{
    public class MapperInitialiser : Profile
    {
        public MapperInitialiser()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();

            CreateMap<TransType, TransTypeDTO>().ReverseMap();
            CreateMap<TransType, CreateTransTypeDTO>().ReverseMap();

            CreateMap<Audit, AuditDTO>().ReverseMap();
            CreateMap<Audit, CreateAuditDTO>().ReverseMap();

            CreateMap<ApiUser, UserDTO>().ReverseMap();

            //CreateMap<Days, DaysDTO>().ReverseMap();
            //CreateMap<Days, CreateDaysDTO>().ReverseMap();

            //CreateMap<Hours, HoursDTO>().ReverseMap();
            //CreateMap<Hours, CreateHoursDTO>().ReverseMap();


        }
    }
}
