using Application.Features.People.Queries.Common;
using Application.Features.People.Queries.GetAllPeople;
using Application.Features.People.Queries.GetPeopleByColor;
using Application.Features.People.Queries.GetPersonById;
using Colors.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Web.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ApiController
    {
        [HttpGet]
        [Route("people")]
        public async Task<ActionResult<IEnumerable<PersonOutputModel>>> GetAllPeople([FromQuery]GetAllPeopleQuery query)
            => await this.Send(query);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonOutputModel>>> GetPeopleByColor([FromQuery]GetPeopleByColorQuery query)
        => await this.Send(query);

        [HttpGet]
        [Route("person")]
        public async Task<ActionResult<PersonOutputModel>> GetPersonById([FromQuery] GetPersonByIdQuery query)
        => await this.Send(query);

    }
}
