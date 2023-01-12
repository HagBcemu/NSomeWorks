using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Client
    {
        public int ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NameCompany { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
