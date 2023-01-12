using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Office
    {
        public int OfficeId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }
        public List<Employee> Employee { get; set; } = new List<Employee>();
    }
}
