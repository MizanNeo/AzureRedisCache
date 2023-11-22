using EMS.Application.Features.Department.Commands.CreateDepartment;
using EMS.Application.Features.Department.Commands.DeleteDepartment;
using EMS.Application.Features.Department.Commands.UpdateDepartment;
using EMS.Application.Features.Department.Queries.GetDepartmentById;
using EMS.Application.Features.Department.Queries.GetDepartmentList;
using EMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IDistributedCache cache;
        private readonly IConfiguration config;
        public DepartmentController(IMediator mediator,IDistributedCache cache,IConfiguration config)
        {
            this.mediator = mediator;
            this.cache = cache;
            this.config= config;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var cachedDepartments = await cache.GetAsync("CachedDepartments");
            if (cachedDepartments != null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<Department>>(cachedDepartments));
            }
            else
            {
                var result= await mediator.Send(new GetDepartmentListQuery());
                await cache.SetAsync("CachedDepartments", JsonSerializer.SerializeToUtf8Bytes(result), new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(config.GetValue<double>("RedisCache:SlidingExpirationMinutes"))));
                return Ok(result);
            }
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        [OutputCache(Duration =120)]
        [ResponseCache(Duration =60)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await mediator.Send(new GetDepartmentByIdQuery { Id=id });
            return Ok(result);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddDepartmentCommand addDepartmentCommand)
        {
            var response=await mediator.Send(addDepartmentCommand);
            return Ok(response);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            var response= await mediator.Send(updateDepartmentCommand);
            return Ok(response);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteDepartmentCommand deleteDepartmentCommand)
        {
            var response = await mediator.Send(deleteDepartmentCommand);
            return Ok(response);
        }
    }
}
