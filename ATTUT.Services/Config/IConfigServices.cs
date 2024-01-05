using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Config
{
    public interface IConfigServices
    {
        #region--------------------Company--------------------
        Task<List<CompanyModel>> CompanyList(object[] parameters);
        Task<CompanyModel> CompanyById(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateCompany(object[] parameters);
        #endregion-----------------Company--------------------

        #region-------Branch-----------
        Task<CreateOrUpdateModel> AddBranch(object[] parameters);
        Task<List<BranchModel>> BranchList(object[] parameters);
        Task<BranchModel> BranchByID(object[] parameters);
        Task<CreateOrUpdateModel> UpdateBranch(object[] parameters);
        Task<CreateOrUpdateModel> UpdateBranchAccount(object[] parameters);
        #endregion-------Branch--------

        #region----------UserRights----------
        Task<IEnumerable<MenuAccessModel>> Menus(object[] parameters);
        Task<CreateOrUpdateModel> AddUserRight(object[] parameters);
        Task<CreateOrUpdateModel> DeleteUserRight(object[] parameters);
        #endregion-------UserRights----------
    }
}
