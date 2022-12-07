using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Contact
    {
        private string _firstName;

        private long _number;

        public Contact(string firsName, long number)
        {
            _firstName = firsName;
            _number = number;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public long Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
