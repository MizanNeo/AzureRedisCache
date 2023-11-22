using AutoMapper;
using EMS.Application.Contracts;
using EMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employee.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Response<Domain.Entities.Employee>>
    {
        private IEmployeeRepository repository;
        private IMapper mapper;
        public AddEmployeeCommandHandler(IEmployeeRepository repository,IMapper mapper)
        {
            this.repository=repository;
            this.mapper=mapper;
        }

        public async Task<Response<Domain.Entities.Employee>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee=mapper.Map<EMS.Domain.Entities.Employee>(request);
            employee.EmployeeId = await repository.AddAsync(employee);
            var response = new Response<Domain.Entities.Employee>(employee);
            return response;
        }
    }
}
