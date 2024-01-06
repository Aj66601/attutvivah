using ATTUT.Data.Models;
using ATTUT.Data.Models.Basics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
          : base(options)
        {
        }
        public DbSet<CreateOrUpdateModel> CreateOrUpdate { get; set; }
        #region---------------------Account-------------------  
        public DbSet<SessionModel> Session { get; set; }
        public DbSet<MenuAccessModel> MenuAccesses { get; set; }
        public DbSet<ProfileModel> Profile { get; set; }
        #endregion-----------------Account-------------------- 

        #region--------------General-------------------  
        public DbSet<CompanyDdlModel> DdlCompany { get; set; }
        public DbSet<DdlUserRoleModel> DdlUserRoles { get; set; }
        public DbSet<CountryDdlModel> DdlCountry { get; set; }
        public DbSet<StateDdlModel> DdlState { get; set; }
        public DbSet<BranchDdlModel> DdlBranch { get; set; }
        public DbSet<DefaultAccountModel> DefaultAccounts { get; set; }
        public DbSet<DdlCompanyBranchModel> DdlCompanyBranches { get; set; }
        public DbSet<DdlCategoryModel> DdlCategories { get; set; }
        public DbSet<DdlBrandModel> DdlBrands { get; set; }
        public DbSet<DdlUoMModel> DdlUoMs { get; set; }
        public DbSet<DdlHSNModel> DdlHSNs { get; set; }
        public DbSet<HSNDetailsModel> HSNDetails { get; set; }
        public DbSet<DdlMstItemsModel> DdlMstItems { get; set; }
        public DbSet<DdlBillAddress> DdlBillAddresses { get; set; }
        public DbSet<DdlShipAddress> DdlShipAddresses { get; set; }
        public DbSet<GetBillingAddressByCustomerIdModel> BillingAddresses { get; set; }
        public DbSet<GetShippingAddressByCustomerIdModel> ShippingAddresses { get; set; }
        public DbSet<DdlMstWarehouseModel> DdlWarehouses { get; set; }
        public DbSet<CustomerInfoModel> CustomerInfos { get; set; }
        public DbSet<ItemPriceInfoModel> ItemPriceInfos { get; set; }
        public DbSet<DdlFiscalModel> DdlFiscal { get; set; }
        public DbSet<DdlMstColorModel> DdlColor { get; set; }

        #endregion-----------------General-------------------   

        #region--------------Config--------------------
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<BranchModel> Branches { get; set; }
        public DbSet<MenuAccessModel> Menus { get; set; }
        #endregion-----------Config--------------------

        #region------------Master-------------------        
        public DbSet<HSNCodeModel> HSNs { get; set; }
        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<WarehouseModel> Warehouses { get; set; }
        public DbSet<DomesticProductModel> DomesticProducts { get; set; }

        #endregion---------Master-----------------

        #region---------Item--------------------
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ItemPriceModel> ItemPrices { get; set; }
        #endregion--------Item------------------

        #region------------Customer------------
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CustomerBillAddressModel> CustomerBillAddresses { get; set; }
        public DbSet<CustomerShipAddressModel> CustomerShipAddresses { get; set; }
        #endregion--------Customer-------------

        #region---------PerformaInvoice------------
        public DbSet<PerformaInvoiceModel> PerformaInvoices { get; set; }
        public DbSet<PerformaInvoiceItemsModel> PerformaInvoiceItems { get; set; }
        public DbSet<PrintPIHeader> PrintPIHeaders { get; set; }
        public DbSet<PrintPIItems> PrintPIItems { get; set; }
        public DbSet<InvoiceItemsModel> InvoiceItems { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        #endregion--------PerformaInvoice----------

        #region-----------StockIn------------
        public DbSet<StockInModel> Stocks { get; set; }
        public DbSet<StockInItemsModel> StockItems { get; set; }
        #endregion--------StockIn-----------

        #region-----------Inventory------------
        public DbSet<InventoryModel> Inventories { get; set; }
        public DbSet<InventoryBookedModel> InventoriesBooked { get; set; }
        #endregion--------Inventory-----------

        #region --------- Employee -------

        public DbSet<EmployeeModel> Employees { get; set; }

        #endregion


        #region ----------- Domestic Order -----------------

        public DbSet<DomesticOrderModel> DomesticOrders { get; set; }
        public DbSet<DomesticOrderItemModel>  DomesticOrderitems { get; set; }
        #endregion


        #region------------Basic Master-------------------      
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<StateModel> States { get; set; }
        public DbSet<DistrictModel> Districts { get; set; }

        #endregion---------Basic Master-----------------
    }
}