using ATTUT.Data.Context;
using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        public SqlDbContext DbContext { get; }

        public EmployeeServices(SqlDbContext _dbContext)
        {
            DbContext = _dbContext;
        }
        public async Task<List<EmployeeModel>> EmployeesList(object[] parameters)
        {
            return await DbContext.Employees.FromSqlRaw("EXEC [Employee_List] {0},{1}", parameters).ToListAsync();
        }
        public async Task<CreateOrUpdateModel> CreateOrUpdateEmployee(object[] parameters)
        {
            return(await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [Employee_INSorUPD] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", parameters).ToListAsync()).First();
        }
    }
}
