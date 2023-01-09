using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NSomeWorks
{
    class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        public DateTime StartedDate { get; set; }

        public int ClientID { get; set; }

        public Client Client { get; set; }

        public List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
    }
}
