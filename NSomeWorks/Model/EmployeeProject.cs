using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NSomeWorks
{
    class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }

        [Column(TypeName = "money")]
        public decimal Rate { get; set; }

        public DateTime StartedDate { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
