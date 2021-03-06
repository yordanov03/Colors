using Application.Features.People.Commands.Create;
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
    [ApiController]
    [Route("persons")]
    public class PeopleController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonOutputModel>>> GetAllPeople(
            [FromQuery] GetAllPeopleQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route("color/{Color}")]
        public async Task<ActionResult<IEnumerable<PersonOutputModel>>> GetPeopleByColor(
            [FromRoute] GetPeopleByColorQuery query)
        => await this.Send(query);

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<PersonOutputModel>> GetPersonById(
            [FromRoute] GetPersonByIdQuery query)
        => await this.Send(query);


        //FromQuery attribute used for sake of easy testing via SwaggerUI
        [HttpPost]
        public async Task<ActionResult<CreatePersonOutputModel>> Create(
           [FromQuery] CreatePersonCommand command)
            => await this.Send(command);

    }
}
