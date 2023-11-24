using MediatR;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Application.Contracts;

namespace EMS.Application.Features.Department.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, IEnumerable<EMS.Domain.Entities.Department>>
    {
        private readonly IAsyncRepository<EMS.Domain.Entities.Department> repository;

        public GetDepartmentListQueryHandler(IAsyncRepository<Domain.Entities.Department> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<EMS.Domain.Entities.Department>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            return await repository.ListAllAsync();
        }
    }
}
