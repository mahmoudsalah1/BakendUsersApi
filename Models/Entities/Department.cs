using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.Models.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string DepartmentName { get; set; }
        [StringLength(20)]
        public string DepartmentCode { get; set; }
    }
}
