 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATTUT.Data.Context;
using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ATTUT.Services.Account
{
    public class AccountServices: IAccountServices
    {
        public SqlDbContext DbContext { get; }

        public AccountServices(SqlDbContext _dbContext)
        {
            DbContext = _dbContext;
        }
        public async Task<SessionModel> Login(object[] parameters)
        {
            return (await DbContext.Session.FromSqlRaw("EXEC [Login_Validate] {0},{1}", parameters).ToListAsync()).First();
        }
        public async Task<List<MenuAccessModel>> MenuAccess(object[] parameters)
        {
            return await DbContext.MenuAccesses.FromSqlRaw("EXEC [MenuAccessRight_SEL] {0}", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> UpdateProfile(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [Employee_UPD] {0},{1},{2},{3},{4},{5}", parameters).ToListAsync()).First();
        }

        public async Task<ProfileModel> Profile_ById(object[] parameters)
        {
            return (await DbContext.Profile.FromSqlRaw("EXEC [Employee_ById] {0},{1}", parameters).ToListAsync()).First();
        }

        public async Task<CreateOrUpdateModel> ChangePassword(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [ChangePassword] {0},{1},{2},{3}", parameters).ToListAsync()).First();
        }
    }
}
