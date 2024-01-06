using ATTUT.Data.Context;
using ATTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.General
{
    public class GeneralServices: IGeneralServices
    {
        public SqlDbContext DbContext { get; }

        public GeneralServices(SqlDbContext _dbContext)
        {
            DbContext = _dbContext;
        }
        public async Task<List<CompanyDdlModel>> DdlCompany(object[] parameters)
        {
            return await DbContext.DdlCompany.FromSqlRaw("EXEC [MstCompany_Ddl] {0}", parameters).ToListAsync();
        }
        public async Task<List<DdlUserRoleModel>> DdlUserRole(object[] parameters)
        {
            return await DbContext.DdlUserRoles.FromSqlRaw("EXEC [MstRole_Ddl] {0}", parameters).ToListAsync();
        }

        public async Task<List<StateDdlModel>> DdlState(object[] parameters)
        {
            return await DbContext.DdlState.FromSqlRaw("EXEC [State_Ddl] {0}", parameters).ToListAsync();
        }
        public async Task<List<CountryDdlModel>> DdlCountry(object[] parameters)
        {
            return await DbContext.DdlCountry.FromSqlRaw("EXEC [Country_Ddl]").ToListAsync();
        }
        public async Task<List<BranchDdlModel>> DdlBranch(object[] parameters)
        {
            return await DbContext.DdlBranch.FromSqlRaw("EXEC [MstBranch_Ddl] {0}", parameters).ToListAsync();
        }
        public async Task<DefaultAccountModel> GetDefaultAccount(object[] parameters)
        {
            return (await DbContext.DefaultAccounts.FromSqlRaw("EXEC [MstBranchBankDetails_SEL] {0},{1},{2}", parameters).ToListAsync()).FirstOrDefault();
        }
        public async Task<List<DdlCompanyBranchModel>> DdlCompanyBranch(object[] parameters)
        {
            return await DbContext.DdlCompanyBranches.FromSqlRaw("EXEC [MstBranch_Ddl_InCompany] {0}", parameters).ToListAsync();
        }
        public async Task<List<HSNDetailsModel>> HSNDetail(object[] parameters)
        {
            return await DbContext.HSNDetails.FromSqlRaw("EXEC [MstHSN_Gen_ById] {0}", parameters).ToListAsync();
        }
        public async Task<List<DdlCategoryModel>> DdlCategory(object[] parameters)
        {
            return await DbContext.DdlCategories.FromSqlRaw("EXEC [MstCategory_Ddl] {0}", parameters).ToListAsync();
        }

        public async Task<List<DdlBrandModel>> DdlBrand(object[] parameters)
        {
            return await DbContext.DdlBrands.FromSqlRaw("EXEC [MstBrand_Ddl] {0}", parameters).ToListAsync();
        }

        public async Task<List<DdlUoMModel>> DdlUoM(object[] parameters)
        {
            return await DbContext.DdlUoMs.FromSqlRaw("EXEC [MstUom_Ddl] {0}", parameters).ToListAsync();
        }
        public async Task<List<DdlHSNModel>> DdlHSN(object[] parameters)
        {
            return await DbContext.DdlHSNs.FromSqlRaw("EXEC [MstHSN_Ddl] {0}", parameters).ToListAsync();
        }
        public async Task<List<DdlMstItemsModel>> DdlMstItems(object[] parameters)
        {
            return await DbContext.DdlMstItems.FromSqlRaw("EXEC [MstItems_Ddl] {0},{1}", parameters).ToListAsync();
        }
        public async Task<List<DdlMstItemsModel>> DdlMstDomesticItems(object[] parameters)
        {
            return await DbContext.DdlMstItems.FromSqlRaw("EXEC [MstDomesticItems_Ddl] {0},{1}", parameters).ToListAsync();
        }

        public async Task<List<GetBillingAddressByCustomerIdModel>> BillingAddressesByCustomerId(object[] parameters)
        {
            return await DbContext.BillingAddresses.FromSqlRaw("EXEC [GetBillingAddressByCustomerId] {0}", parameters).ToListAsync();
        }

        public async Task<List<GetShippingAddressByCustomerIdModel>> ShippingAddressesByCustomerId(object[] parameters)
        {
            return await DbContext.ShippingAddresses.FromSqlRaw("EXEC [GetShippingAddressByCustomerId] {0}", parameters).ToListAsync();
        }

        public async Task<List<DdlMstWarehouseModel>> DdlWarehouse(object[] parameters)
        {
            return await DbContext.DdlWarehouses.FromSqlRaw("EXEC [MstWarehouse_Ddl] {0},{1}", parameters).ToListAsync();
        }

        public async Task<List<DdlBillAddress>> DdlBillAddresses(object[] parameters)
        {
            return await DbContext.DdlBillAddresses.FromSqlRaw("EXEC [MstCustomerBillAddress_Ddl] {0}", parameters).ToListAsync();
        }

        public async Task<List<DdlShipAddress>> DdlShipAddresses(object[] parameters)
        {
            return await DbContext.DdlShipAddresses.FromSqlRaw("EXEC [MstCustomerShipAddress_Ddl] {0}", parameters).ToListAsync();
        }

        public async Task<List<CustomerBillAddressModel>> CustomerBillAddress(object[] parameters)
        {
            return await DbContext.CustomerBillAddresses.FromSqlRaw("EXEC [MstCustomerBillAddress_ById] {0}", parameters).ToListAsync();
        }

        public async Task<List<CustomerShipAddressModel>> CustomerShipAddress(object[] parameters)
        {
            return await DbContext.CustomerShipAddresses.FromSqlRaw("EXEC [MstCustomerShipAddress_ById] {0}", parameters).ToListAsync();
        }

        public async Task<CustomerInfoModel> CustomerInfo(object[] parameters)
        {
            var result = await DbContext.CustomerInfos.FromSqlRaw("EXEC [MstCustomer_Info] {0},{1}", parameters).ToListAsync();
            if (result.Any())
                return result.First();
            else
                return new();
        }          
        public async Task<ItemPriceInfoModel> ItemPriceInfo(object[] parameters)
        {
            return (await DbContext.ItemPriceInfos.FromSqlRaw("EXEC [MstItemPrice_Info] {0},{1}", parameters).ToListAsync()).First();
        }

        public async Task<List<BranchDdlModel>> DdlBranch_ByEmpId(object[] parameters)
        {
            return await DbContext.DdlBranch.FromSqlRaw("EXEC [MstBranch_ByEmpId] {0},{1}", parameters).ToListAsync();
        }
        public async Task<List<DdlFiscalModel>> DdlFiscal(object[] parameters)
        {
            return await DbContext.DdlFiscal.FromSqlRaw("EXEC [Fiscal_Ddl] {0}", parameters).ToListAsync();
        }
        public async Task<List<DdlMstColorModel>> DdlColor(object[] parameters)
        {
            return await DbContext.DdlColor.FromSqlRaw("EXEC [MstColor_Ddl] {0}", parameters).ToListAsync();
        }
    }
}
