using EMS.Application.Contracts;
using EMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, EMS.Domain.Entities.Department>
    {
        private IAsyncRepository<EMS.Domain.Entities.Department> repository;

        public GetDepartmentByIdHandler(IAsyncRepository<Domain.Entities.Department> repository)
        {
            this.repository=repository;
        }

        public async Task<Domain.Entities.Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByIdAsync(request.Id);
        }
    }
}
