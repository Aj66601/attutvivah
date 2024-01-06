using ATTUT.Data.Models;
using ATTUT.Data.Models.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Basics
{
    public interface IBasicMasterServices
    {
        #region--------------------Country--------------------
        Task<List<CountryModel>> CountryList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateCountry(object[] parameters);
        #endregion-----------------Country--------------------

        #region--------------------State--------------------
        Task<List<StateModel>> StateList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateState(object[] parameters);
        #endregion-----------------State--------------------

        #region--------------------District--------------------
        Task<List<DistrictModel>> DistrictList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateDistrict(object[] parameters);
        #endregion-----------------District--------------------
    }
}
