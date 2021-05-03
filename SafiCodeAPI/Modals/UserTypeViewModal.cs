using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafiCodeAPI.Modals
{
    public class UserTypeViewModal
    {
        public long UserTypeId { get; set; }
        public string UserType { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}
