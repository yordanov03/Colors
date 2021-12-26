using Application.Mapping;
using Domain.Models;

namespace Application.Features.People.Queries.Common
{
    public class PersonOutputModel : IMapFrom<Person>
    {
        public int Id { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public string Zipcode { get;  set; }
        public string City { get; set; }
        public string Color { get; set; }
    }
}
