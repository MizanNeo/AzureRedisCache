using EMS.Application.Contracts;
using EMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Commands.CreateDepartment
{
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentCommand, Response<EMS.Domain.Entities.Department>>
    {
        private readonly IAsyncRepository<EMS.Domain.Entities.Department> repository;
        public AddDepartmentHandler(IAsyncRepository<EMS.Domain.Entities.Department> repository) 
        { 
            this.repository = repository;
        }
        public async Task<Response<EMS.Domain.Entities.Department>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new EMS.Domain.Entities.Department() { DepartmentName = request.DeptName };
            department= await repository.AddAsync(department);
            var response = new Response<EMS.Domain.Entities.Department>(department, "success");
            return response;
        }
    }
}
