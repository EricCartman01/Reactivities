using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            //return await Mediator.Send(new List.Query());
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            //var result = await Mediator.Send(new Details.Query { Id = id });
            //return HandleResult(result);
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
     
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command{ Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            //return Ok(await Mediator.Send(new Delete.Command { Id = id }));
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatActivity(Activity activity)
        {
            //return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }
    }
}
