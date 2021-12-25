using System.Collections.Generic;

namespace Application.Features.People.Queries.Common
{
    public class PeopleOutputModel
    {
        public PeopleOutputModel(IEnumerable<PersonOutputModel> people)
        {
            this.People = people;
        }
        IEnumerable<PersonOutputModel> People { get; }
    }
}
