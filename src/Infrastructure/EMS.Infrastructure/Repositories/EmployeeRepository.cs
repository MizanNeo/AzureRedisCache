using EMS.Application.Contracts;
using EMS.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<int> AddAsync(Employee employee)
        {
            var parameterReturn = new SqlParameter
            {
                ParameterName = "@ReturnValue",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            await dbContext.Database.ExecuteSqlRawAsync("[dbo].AddEmployee @EmployeeName,@Email,@Mobile,@BirthDate,@JoinDate,@DepartmentId,@Salary,@Pan,@Gender,@PassportNumber,@ReturnValue OUTPUT", parameters: new[] { parameterReturn,
                new SqlParameter("@EmployeeName",employee.EmployeeName),
                new SqlParameter("@Email",employee.Email),
                new SqlParameter("@Mobile",employee.Mobile),
                new SqlParameter("@BirthDate",employee.BirthDate),
                new SqlParameter("@JoinDate",employee.JoinDate),
                new SqlParameter("@DepartmentId",employee.DepartmentId),
                new SqlParameter("@Salary",employee.Salary),
                new SqlParameter("@Pan",employee.Pan),
                new SqlParameter("@Gender",employee.Gender),
                new SqlParameter("@PassportNumber",employee.PassportNumber)
            });

            return (int)parameterReturn.Value;
        }
    }
}
