using EMS.Application.Features.Employee.Commands.AddEmployee;
using EMS.Application.Features.Employee.Commands.UpdateEmployeePhoto;
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
        private readonly IWebHostEnvironment webHost;
        private readonly IHttpContextAccessor httpContextAccessor;
        public EmployeeController(IMediator mediator, IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator=mediator;
            this.webHost=webHost;
            this.httpContextAccessor=httpContextAccessor;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { webHost.ContentRootPath, httpContextAccessor.HttpContext.Request.Scheme , httpContextAccessor.HttpContext.Request.Host.ToString() , httpContextAccessor.HttpContext.Request.Path };
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfilePhoto(int id,IFormFile profilePhoto)
        {
            if(profilePhoto != null && id>0)
            {
                using(var stream = profilePhoto.OpenReadStream())
                {
                    UpdatePhotoCommand photoCommand = new UpdatePhotoCommand() { Id=id,FileName=profilePhoto.FileName, ProfilePhoto = stream};
                    var response = await mediator.Send(photoCommand);
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
