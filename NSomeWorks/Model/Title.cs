using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Title
    {
        public int TitleId { get; set; }

        public string Name { get; set; }
        public virtual List<Employee> Employee { get; set; } = new List<Employee>();
    }
}
