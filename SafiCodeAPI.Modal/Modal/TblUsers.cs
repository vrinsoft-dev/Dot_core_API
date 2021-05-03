using System;
using System.Collections.Generic;

namespace SafiCodeAPI.Modal.Modal
{
    public partial class TblUsers
    {
        public long UserId { get; set; }
        public long? UserTypeId { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Industry { get; set; }
        public bool? IstermsCondition { get; set; }
        public int? ClientType { get; set; }
        public string HouseOfficeNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Zip { get; set; }
        public long? CountryId { get; set; }
        public string CurrencyName { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public long? ModifyBy { get; set; }
        public TblUserType UserType { get; set; }
    }
}
