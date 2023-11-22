using EMS.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Response<int>>
    {
        private readonly IAsyncRepository<EMS.Domain.Entities.Department> repository;

        public DeleteDepartmentHandler(IAsyncRepository<Domain.Entities.Department> repository)
        {
            this.repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new EMS.Domain.Entities.Department() { DepartmentId = request.Id };
            await repository.DeleteAsync(department);
            return new Response<int>(request.Id, "Deleted successfully.");
        }
    }
}
