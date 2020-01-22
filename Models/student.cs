using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bootstrap.Models
{
    public class DepartmentMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<EmployeeMaster> Employees { get; set; }
    }

    public class EmployeeMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentMaster Department { get; set; }
    }
}
