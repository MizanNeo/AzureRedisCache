using EMS.Application.Features.Employee.Commands.AddEmployee;
using EMS.Application.Features.Employee.Commands.UpdateEmployeePhoto;
using EMS.Application.Features.Employee.Queries.GetEmployeeList;
using EMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeeController(IMediator mediator)
        {
            this.mediator=mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await mediator.Send(new GetEmployeeListQuery());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEmployeeCommand employee)
        {
            var response=await mediator.Send(employee);
            return Ok(response);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("PutProfilePhoto/{id}")]
        public async Task<IActionResult> PutProfilePhoto(int id,IFormFile profilePhoto)
        {
            if(profilePhoto != null && id>0)
            {
                using(var stream = profilePhoto.OpenReadStream())
                {
                    UpdatePhotoCommand photoCommand = new UpdatePhotoCommand() { Id=id,FileName=profilePhoto.FileName, ProfilePhoto = stream};
                    var response = await mediator.Send(photoCommand);
                    if (response.Succeeded) return Ok(response);
                    else BadRequest(response);
                }
            }
            return BadRequest();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
