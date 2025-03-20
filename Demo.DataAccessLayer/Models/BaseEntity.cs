using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } // PK
        public int CreatedBy { get; set; } // User Id
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } // User Id 
        public DateTime LastModifiedOn { get; set; } // Calculated on BD
        public bool IsDeleted { get; set; } // Flag to Soft Deleted
    }
}
