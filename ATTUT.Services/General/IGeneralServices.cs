
using ATTUT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Services.General
{
    public interface IGeneralServices
    {
        Task<List<CompanyDdlModel>> DdlCompany(object[] parameters);
        Task<List<DdlUserRoleModel>> DdlUserRole(object[] parameters);
        Task<List<StateDdlModel>> DdlState(object[] parameters);
      
        Task<List<CountryDdlModel>> DdlCountry(object[] parameters);
        Task<List<BranchDdlModel>> DdlBranch(object[] parameters);
        Task<DefaultAccountModel> GetDefaultAccount(object[] parameters);
        Task<List<DdlCompanyBranchModel>> DdlCompanyBranch(object[] parameters);
        Task<List<DdlCategoryModel>> DdlCategory(object[] parameters);
        Task<List<DdlBrandModel>> DdlBrand(object[] parameters);
        Task<List<DdlUoMModel>> DdlUoM(object[] parameters);
        Task<List<DdlHSNModel>> DdlHSN(object[] parameters);
        Task<List<DdlMstItemsModel>> DdlMstItems(object[] parameters);
        Task<List<DdlMstItemsModel>> DdlMstDomesticItems(object[] parameters);
        Task<List<HSNDetailsModel>> HSNDetail(object[] parameters);
        Task<List<GetBillingAddressByCustomerIdModel>> BillingAddressesByCustomerId(object[] parameters);
        Task<List<GetShippingAddressByCustomerIdModel>> ShippingAddressesByCustomerId(object[] parameters);
        Task<List<DdlMstWarehouseModel>> DdlWarehouse(object[] parameters);
        Task<List<DdlBillAddress>> DdlBillAddresses(object[] parameters);
        Task<List<DdlShipAddress>> DdlShipAddresses(object[] parameters);
        Task<List<CustomerBillAddressModel>> CustomerBillAddress(object[] parameters);
        Task<List<CustomerShipAddressModel>> CustomerShipAddress(object[] parameters);
        Task<CustomerInfoModel> CustomerInfo(object[] parameters);
        Task<ItemPriceInfoModel> ItemPriceInfo(object[] parameters);
        Task<List<BranchDdlModel>> DdlBranch_ByEmpId(object[] parameters);
        Task<List<DdlFiscalModel>> DdlFiscal(object[] parameters);
        Task<List<DdlMstColorModel>> DdlColor(object[] parameters);
    }
}
