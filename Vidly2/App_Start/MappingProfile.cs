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
            #region AutoMapper Initialization
            //Creating mapping configuration between two types.
            //So here we're mapping a Customer obj to CustomerDto obj.
            //Automapper uses reflection to scan those types then it 
            //scans their properties and maps them based on their name.
            //Thats why it's called a Convention-based Mapping Tool, 
            //because it uses property names as a convention to map objects.
            #endregion
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            /*.ForMember() is needed here to resolve exception during updating 
             * a resource at "Mapper.Map(customerDto, customer)" with a message
             * "Property ‘Id’ is part of object’s key information and cannot be modified".
             * The exception is thrown when AutoMapper attempts to set the Id of movie:
                customer.Id	=	customerDto.Id;	
                Id is the key property for the Customer class, and a key property should not be changed.
                That’s why we get this exception. To resolve this, you need to tell AutoMapper to ignore
                Id during mapping of a CustomerDto to Customer.               
             */

            #region Section 6 Exercise:
            /*Section 6 Exercise:
             * WEB API for CRUD operations around Movies:
             * 1)Initialize mapping configuration in MappingProfile from 
             *    Movie to MovieDto and the other way around. 
             * 2) Create MovieDto to not rely on Movie domain model.
             * 3) Create MoviesController in Controllers/Api folder for all logic. 
             * 4) Test with Postman every URI path from API MoviesController.cs
             * 5) Optional: enable camel notation in WebApiConfig.cs                            
             */
            #endregion
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }

    }
}
