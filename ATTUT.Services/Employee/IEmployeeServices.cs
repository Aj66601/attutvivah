using ATTUT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Employee
{
    public interface IEmployeeServices
    {
        #region ---------- Employees--------
        Task<List<EmployeeModel>> EmployeesList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateEmployee(object[] parameters);

        #endregion
    }
}
