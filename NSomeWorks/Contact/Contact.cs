using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NSomeWorks
{
    class Contact : IComparable<Contact>
    {
        private string _name;

        private string _phoneNumber;

        public Contact(string name, string phonenumber)
        {
            _name = name;
            _phoneNumber = phonenumber;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public int CompareTo(Contact contact)
        {
            return Name.CompareTo(contact.Name);
        }
    }
}
