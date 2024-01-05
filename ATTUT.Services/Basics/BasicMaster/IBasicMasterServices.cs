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
    }
}
