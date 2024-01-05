using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Master
{
    public interface IMasterServices
    {
        #region--------------------HSN--------------------
        Task<List<HSNCodeModel>> HSNs(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateHSNs(object[] parameters);
        #endregion-----------------HSN--------------------  

        #region--------------------Brand--------------------
        Task<List<BrandModel>> BrandList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateBrand(object[] parameters);
        #endregion-----------------Brand-------------------- 

        #region--------------------Category--------------------
        Task<List<CategoryModel>> CategoryList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateCategory(object[] parameters);
        #endregion-----------------Category--------------------

        #region--------------------Warehouse--------------------
        Task<List<WarehouseModel>> WarehouseList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateWarehouse(object[] parameters);
        #endregion-----------------Warehouse--------------------

        #region ------------- Domestic Products ---------------
        Task<List<DomesticProductModel>> DomesticList(object[] parameters);
        Task<CreateOrUpdateModel> CreateOrUpdateDomesticProduct(object[] parameters);
        #endregion
    }
}
