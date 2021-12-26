using Application.Features.People.Queries.Common;
using AutoMapper;
using Domain.Models;
using System.Reflection;

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
