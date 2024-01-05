using ATTUT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Account
{
    public interface IAccountServices
    {
        Task<SessionModel> Login(object[] parameters);
        Task<List<MenuAccessModel>> MenuAccess(object[] parameters);

        #region----------Profile-------------------------
        Task<ProfileModel> Profile_ById(object[] parameters);
        Task<CreateOrUpdateModel> UpdateProfile(object[] parameters);
        Task<CreateOrUpdateModel> ChangePassword(object[] parameters);

        #endregion-------Profile-------------------------
    }
}
