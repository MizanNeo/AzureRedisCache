using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employee.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<Response<Domain.Entities.Employee>>
    {
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public char Gender { get; set; }
        public int DepartmentId { get; set; }
        public double Salary { get; set; }
        public string Pan { get; set; }
        public string PassportNumber { get; set; }
    }
}
