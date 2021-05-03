using System;
using System.Collections.Generic;

namespace SafiCodeAPI.Modal.Modal
{
    public partial class TblUserType
    {
        public TblUserType()
        {
            TblUsers = new HashSet<TblUsers>();
        }

        public long UserTypeId { get; set; }
        public string UserType { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<TblUsers> TblUsers { get; set; }
    }
}
