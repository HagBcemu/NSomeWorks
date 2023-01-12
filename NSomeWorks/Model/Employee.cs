﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NSomeWorks
{
    [Table("Employee")]
    class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HiredDate { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public int TitleId { get; set; }

        public Title Title { get; set; }

        public List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
    }
}
