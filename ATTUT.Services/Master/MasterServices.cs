using ATTUT.Data.Context;
using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.Master
{
    public class MasterServices : IMasterServices
    {
        public SqlDbContext DbContext { get; }
        public MasterServices(SqlDbContext _dbContext)
        {
            DbContext = _dbContext;
        }
        #region--------------------HSN--------------------
        public async Task<List<HSNCodeModel>> HSNs(object[] parameters)
        {
            return await DbContext.HSNs.FromSqlRaw("EXEC [MstHSN_ListorSingle] {0},{1}", parameters).ToListAsync();
        }
        public async Task<CreateOrUpdateModel> CreateOrUpdateHSNs(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstHSN_INSorUPD] {0},{1},{2},{3},{4},{5},{6},{7},{8}, {9}", parameters).ToListAsync()).First();
        }
        #endregion-----------------HSN--------------------

        #region--------------------Brand--------------------
        public async Task<List<BrandModel>> BrandList(object[] parameters)
        {
            return await DbContext.Brands.FromSqlRaw("EXEC [MstBrand_List] {0},{1}", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> CreateOrUpdateBrand(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstBrand_INSorUPD] {0},{1},{2},{3},{4}", parameters).ToListAsync()).First();
        }
        #endregion-----------------Brand--------------------

        #region--------------------Category--------------------
        public async Task<List<CategoryModel>> CategoryList(object[] parameters)
        {
            return await DbContext.Categories.FromSqlRaw("EXEC [MstCategory_List] {0},{1}", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> CreateOrUpdateCategory(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstCategory_INSorUPD] {0},{1},{2},{3},{4}", parameters).ToListAsync()).First();
        }
        #endregion--------------------Category--------------------

        #region--------------------Warehouse--------------------
        public async Task<List<WarehouseModel>> WarehouseList(object[] parameters)
        {
            return await DbContext.Warehouses.FromSqlRaw("EXEC [MstWarehouse_List] {0},{1}", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> CreateOrUpdateWarehouse(object[] parameters)
        {
            return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstWarehouse_INSorUPD] {0},{1},{2},{3},{4},{5},{6}", parameters).ToListAsync()).First();
        }
        #endregion--------------------Warehouse--------------------

        #region ------------Domestic Product-----------
            
        public async Task<List<DomesticProductModel>> DomesticList(object[] parameters)
        {
            return await DbContext.DomesticProducts.FromSqlRaw("EXEC [MstDomesticProduct_List] {0}, {1} ", parameters).ToListAsync();
        }

        public async Task<CreateOrUpdateModel> CreateOrUpdateDomesticProduct(object[] parameters)
        {
            try
            {
                return (await DbContext.CreateOrUpdate.FromSqlRaw("EXEC [MstDomesticProductsINSorUPD] {0},{1},{2},{3},{4},{5},{6}", parameters).ToListAsync()).First();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            }
        #endregion
    }
}
