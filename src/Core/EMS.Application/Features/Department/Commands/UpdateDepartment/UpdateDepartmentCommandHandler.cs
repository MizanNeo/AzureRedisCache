using EMS.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Response<int>>
    {
        private readonly IAsyncRepository<EMS.Domain.Entities.Department> repository;
        public UpdateDepartmentCommandHandler(IAsyncRepository<Domain.Entities.Department> repository)
        {
            this.repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {

            var department = new EMS.Domain.Entities.Department() { DepartmentId=request.Id, DepartmentName = request.DeptName };
            await repository.UpdateAsync(department);
            return new Response<int>(request.Id, "Updated successfully.");
        }
    }
}
