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
        // class which explicitly maps Models to DTOs. Also mapped both ways using .ReverseMap
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

         


        }
    }
}
