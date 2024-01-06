using ATTUT.Data.Models;
using ATTUT.Services.General;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis.Operations;

namespace ATTUT.Controllers
{
    public class GeneralController : BaseController
    {
        private readonly IGeneralServices _generalServices;
        public GeneralController(IGeneralServices generalServices)
        {
            _generalServices = generalServices;
        }
        #region EncryptionDecryption  
        readonly string Key = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string EncryptData(string encryptString)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        public string DecryptData(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion EncryptionDecryption
        #region ConvertNumberToWord
        public string ConvertNumbertoWords(int number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKH ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
        #endregion ConvertNumberToWord
        public ValidateResultModel ValidateDate(string? date )
        {
            ValidateResultModel dbResponseModel = new ValidateResultModel();
            try
            {
                if (string.IsNullOrEmpty(date))
                {
                    dbResponseModel.InfoCode = 0;
                    dbResponseModel.InfoMessage = string.Empty;
                }
                else if (date.Trim() != null)
                {
                    Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

                    //Verify whether date entered in dd/MM/yyyy format.
                    bool isValid = regex.IsMatch(date.Trim());

                    //Verify whether entered date is Valid date.
                    DateTime dt;
                    isValid = DateTime.TryParseExact(date.Trim(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
                    if (isValid == true)
                    {
                        dbResponseModel.InfoCode = 0;
                        string rdate = Convert.ToDateTime(dt).ToString("yyyy-MM-dd");
                        dbResponseModel.InfoMessage = rdate;
                    }
                    else
                        dbResponseModel.InfoCode = 1;
                    
                }
                else
                {
                    dbResponseModel.InfoCode = 1;
                    dbResponseModel.InfoMessage = string.Empty;
                }

            }
            catch (Exception ex)
            {
                dbResponseModel.InfoCode = 1;
                dbResponseModel.InfoMessage = ex.Message;

            }
            return dbResponseModel;
        }
        public string FormatedDate()
        {
            string dayt, montht, date;
            int day, month;
            day = DateTime.Now.Day;
            month = DateTime.Now.Month;
            if (day < 10)
                dayt = "0" + DateTime.Now.Day;
            else
                dayt = DateTime.Now.Day.ToString();
            if (month < 10)
                montht = "0" + DateTime.Now.Month;
            else
                montht = DateTime.Now.Month.ToString();
            date = dayt + "/" + montht + "/" + DateTime.Now.Year;
            return date;
        }
        public IEnumerable<CompanyDdlModel> DdlCompany()
        {
            object[] parameter = { GetSession().UserId };
            return _generalServices.DdlCompany(parameter).Result;
        }
        public IEnumerable<DdlUserRoleModel> DdlUserRole(int cid = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid };
            return _generalServices.DdlUserRole(parameter).Result;
        }
        public IEnumerable<DdlMstWarehouseModel> DdlWarehouse(int cid = 0, int branchId = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid, branchId };
            var result = _generalServices.DdlWarehouse(parameter).Result;
            return result;
        }
        public IEnumerable<BranchDdlModel> DdlBranch(int cid = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid };
            return _generalServices.DdlBranch(parameter).Result;
        }
        
        public IEnumerable<DdlMstItemsModel> DdlDomesticItem(int branchId)
        {
            object[] parmeters = { GetSession().CompanyId, branchId };
            return _generalServices.DdlMstDomesticItems(parmeters).Result;
           
        }
        public IEnumerable<StateDdlModel> DdlState(int cid = 0)
        {
            object[] parameter = { cid };
            return _generalServices.DdlState(parameter).Result;
        }
        public IEnumerable<CountryDdlModel> DdlCountry(int cid = 0)
        {
            object[] parameter = { cid };
            return _generalServices.DdlCountry(parameter).Result;
        }
        public JsonResult DdlState_Json(int cid = 0)
        {
            object[] parameter = { cid };
            return Json(_generalServices.DdlState(parameter).Result);
        }
        public JsonResult DdlWarehouse_Json(int branchId = 0)
        {
            object[] parameter = { GetSession().CompanyId, branchId };
            return Json(_generalServices.DdlWarehouse(parameter).Result);
        }
        public JsonResult GetDefaultAccount_Json(int AccountType, int BranchID, int cid)
        {
            object[] paraeters = { AccountType, BranchID, cid };
            return Json(_generalServices.GetDefaultAccount(paraeters).Result);
        }
        public IEnumerable<DdlCategoryModel> DdlCategory(int cid = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid };
            return _generalServices.DdlCategory(parameter).Result;
        }
        public IEnumerable<DdlBrandModel> DdlBrand(int cid = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid };
            return _generalServices.DdlBrand(parameter).Result;
        }
        public IEnumerable<DdlUoMModel> DdlUoM(int cid = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid };
            return _generalServices.DdlUoM(parameter).Result;
        }
        public IEnumerable<DdlHSNModel> DdlHSN(int cid = 0)
        {
            object[] parameter = { cid == 0 ? GetSession().CompanyId : cid };
            return _generalServices.DdlHSN(parameter).Result;
        }
        public JsonResult DdlCompanyBranch_Json(int cid)
        {
            object[] parmeters = { cid };
            var data = _generalServices.DdlCompanyBranch(parmeters).Result;
            return Json(data);
        }

        public JsonResult DdlMstItems_Json(int branchId)
        {
            object[] parmeters = { GetSession().CompanyId, branchId };
            var data = _generalServices.DdlMstItems(parmeters).Result;
            return Json(data);
        }



        public IActionResult GetHSNDetails(int id)
        {
            object[] parmeters = { id };
            var _Result = _generalServices.HSNDetail(parmeters).Result;
            return PartialView("_hSNDetails", _Result.First());
        }

        public IEnumerable<DdlBillAddress> DdlBillAddresses(int customerId = 0)
        {
            object[] parameter = { customerId };
            return _generalServices.DdlBillAddresses(parameter).Result;
        }

        public IEnumerable<DdlShipAddress> DdlShipAddresses(int customerId = 0)
        {
            object[] parameter = { customerId };
            return _generalServices.DdlShipAddresses(parameter).Result;
        }

        public IActionResult GetCustomerDetails(string contactNo)
        {
            object[] parmeters = { GetSession().CompanyId, contactNo };
            var _Result = _generalServices.CustomerInfo(parmeters).Result;            
            return Json(_Result);
        }
        public IActionResult ItemPriceInfo(int branchId, int itemId)
        {
            object[] parmeters = { itemId, branchId }; 
            var _Result = _generalServices.ItemPriceInfo(parmeters).Result;
            return Json(_Result);
        }
        public IEnumerable<CustomerBillAddressModel> GetBillingAddress(int customerId)
        {
            object[] parameter = { customerId };
            return _generalServices.CustomerBillAddress(parameter).Result;
        }

        public IEnumerable<CustomerShipAddressModel> GetShippingAddress(int customerId)
        {
            object[] parameter = { customerId };
            return _generalServices.CustomerShipAddress(parameter).Result;
        }
        public IEnumerable<BranchDdlModel> DdlBranch_ByEmpId()
        {
            object[] parameter = { GetSession().CompanyId, GetSession().UserId };
            return  _generalServices.DdlBranch_ByEmpId(parameter).Result;
        }

        public IEnumerable<DdlFiscalModel> DdlFiscal()
        {
            object[] parameter = { GetSession().CompanyId};
            return _generalServices.DdlFiscal(parameter).Result;
        }

        //public IEnumerable<DdlMstColorModel> DdlColor()
        //{
        //    object[] parameter = { GetSession().CompanyId };
        //    return _generalServices.DdlColor(parameter).Result;
        //}
    }
}
