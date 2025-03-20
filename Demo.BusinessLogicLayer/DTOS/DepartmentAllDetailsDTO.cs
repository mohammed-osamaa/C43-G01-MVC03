using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.DTOS
{
    public class DepartmentAllDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } =string.Empty;
        public string Code { get; set; } = string.Empty;
        public int CreatedBy { get; set; } 
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }  
        public DateOnly LastModifiedOn { get; set; } 
        public bool IsDeleted { get; set; } 
    }
}
