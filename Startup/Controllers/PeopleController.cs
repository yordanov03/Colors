using Application.Features.People.Queries.Common;
using Colors.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Startup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonOutputModel>>> GetAllPeople([FromQuery]GetAllPeopleQuery query)
            => await this.Send(query);
    }
}
