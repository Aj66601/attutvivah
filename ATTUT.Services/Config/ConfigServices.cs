using ATTUT.Data.Context;
using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Config
{
    public class ConfigServices : IConfigServices
    {
        public SqlDbContext DbContext { get; }

        public ConfigServices(SqlDbContext _dbContext)
        {
            DbContext = _dbContext;
        }
        #region--------------------Company--------------------
        public async Task<List<CompanyModel>> CompanyList(object[] parameters)
        {
            return await DbContext.Companies.FromSqlRaw("EXEC [MstCompany_List] {0}", parameters).ToListAsync();
        }
        public async Task<CompanyModel> CompanyById(object[] parameters)
        {
            return (await DbContext.Companies.FromSqlRaw("EXEC [MstCompany_ByID] {0}", parameters).ToListAsync()).First();
        }
        public async Task<CreateOrUpdateModel> CreateOrUpdateCompany(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstCompany_INSorUPD] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", parameters).ToListAsync()).First();
        }
        #endregion-----------------Company--------------------

        #region-------Branch-----------
        public async Task<CreateOrUpdateModel> AddBranch(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstBranch_INS] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", parameters).ToListAsync()).First();
        }
        public async Task<List<BranchModel>> BranchList(object[] parameters)
        {
            return await DbContext.Branches.FromSqlRaw("EXEC [MstBranch_List] {0}", parameters).ToListAsync();
        }
        public async Task<BranchModel> BranchByID(object[] parameters)
        {
            return (await DbContext.Branches.FromSqlRaw("EXEC [MstBranch_ByID] {0}", parameters).ToListAsync()).First();
        }
        public async Task<CreateOrUpdateModel> UpdateBranch(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstBranch_UPD]  {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", parameters).ToListAsync()).First();
        }
        public async Task<CreateOrUpdateModel> UpdateBranchAccount(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstBranchBankDetails_INS_UPD] {0},{1},{2},{3},{4},{5},{6}", parameters).ToListAsync()).First();
        }
        #endregion-------Branch--------

        #region----------UserRights----------
        public async Task<IEnumerable<MenuAccessModel>> Menus(object[] parameters)
        {
            return await DbContext.Menus.FromSqlRaw("EXEC [MstMenu_List] {0},{1}", parameters).ToListAsync();
        }
        public async Task<CreateOrUpdateModel> AddUserRight(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [UserRight_INS] {0},{1},{2}", parameters).ToListAsync()).First();
        }
        public async Task<CreateOrUpdateModel> DeleteUserRight(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [UserRight_DEL] {0}", parameters).ToListAsync()).First();
        }
        #endregion-------UserRights----------
    }
}
