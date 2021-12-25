using Application.Mapping;
using Domain.Models;

namespace Application.Features.People.Queries.Common
{
    public class PersonOutputModel : IMapFrom<Person>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public string Color { get; private set; }
    }
}
