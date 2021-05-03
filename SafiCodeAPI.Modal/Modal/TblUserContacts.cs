using System;
using System.Collections.Generic;

namespace SafiCodeAPI.Modal.Modal
{
    public partial class TblUserContacts
    {
        public long UserContactId { get; set; }
        public long UserId { get; set; }
        public string ContactName { get; set; }
        public string EmailId { get; set; }
        public string Title { get; set; }
        public string MainPhone { get; set; }
        public string MobilePhone { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public long? ModifyBy { get; set; }
    }
}
