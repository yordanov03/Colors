using Application.Features.People.Queries.Common;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
             => this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            CreateMap<Person, PersonOutputModel>();
        }
    }
}
