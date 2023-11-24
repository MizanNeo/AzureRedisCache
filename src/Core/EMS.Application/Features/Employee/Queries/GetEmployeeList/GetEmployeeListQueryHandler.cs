using EMS.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace EMS.Application.Features.Employee.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, IEnumerable<EMS.Domain.Entities.Employee>>
    {
        private readonly IAsyncRepository<EMS.Domain.Entities.Employee> empRepos;
        private readonly IConfiguration config;
        public GetEmployeeListQueryHandler(IAsyncRepository<Domain.Entities.Employee> empRepos, IConfiguration config)
        {
            this.empRepos = empRepos;
            this.config = config;
        }

        public async Task<IEnumerable<Domain.Entities.Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var empList = empRepos.ListAllAsync().Result.Select(emp=>new Domain.Entities.Employee 
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                Email=emp.Email,
                Pan=emp.Pan, 
                ProfileImage= emp.ProfileImage!=null ? config.GetSection("BlobStorage:BlobAccessURL").Value.Replace("[blobName]", emp.ProfileImage):null,
                Mobile=emp.Mobile,
                BirthDate=emp.BirthDate,
                Gender=emp.Gender,
                JoinDate=emp.JoinDate,
                DepartmentId=emp.DepartmentId
            });
                          
            return empList;
        }
    }
}
