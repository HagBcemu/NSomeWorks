using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class GroupContact
    {
        private string _groupName;

        private List<Contact> _contacts;
        public GroupContact()
        {
            _contacts = new List<Contact>();
        }

        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        public List<Contact> GetListContact()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }
    }
}
