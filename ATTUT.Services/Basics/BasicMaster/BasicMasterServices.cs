using ATTUT.Data.Context;
using ATTUT.Data.Models.Basics;
using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Basics.BasicMaster
{
    public class BasicMasterServices : IBasicMasterServices
    {
        public SqlDbContext DbContext { get; }
        public BasicMasterServices(SqlDbContext _dbContext)
        {
            DbContext = _dbContext;
        }

        #region--------------------Country--------------------
        public async Task<List<CountryModel>> CountryList(object[] parameters)
        {
            return await DbContext.Countries.FromSqlRaw("EXEC [MstCountry_List] {0}", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> CreateOrUpdateCountry(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstCountry_INSorUPD] {0},{1},{2},{3},{4}", parameters).ToListAsync()).First();
        }
        #endregion--------------------Country--------------------

        #region--------------------State--------------------
        public async Task<List<StateModel>> StateList(object[] parameters)
        {
            return await DbContext.States.FromSqlRaw("EXEC [MstState_List] {0}", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> CreateOrUpdateState(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstState_INSorUPD] {0},{1},{2},{3},{4},{5}", parameters).ToListAsync()).First();
        }
        #endregion--------------------State--------------------
    }
}
