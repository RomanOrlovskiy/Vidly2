using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Creating mapping configuration between two types.
            //So here we're mapping a Customer obj to CustomerDto obj.
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            //Automapper uses reflection to scan those types then it 
            //scans their properties and maps them based on their name.
            //Thats why it's called a Convention-based Mapping Tool, 
            //because it uses property names as a convention to map objects.
        }

    }
}
