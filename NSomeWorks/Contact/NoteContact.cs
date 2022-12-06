using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NSomeWorks
{
    enum Language
    {
        English,
        Ukrainian,
    }

    class NoteContact
    {
        private List<Contact> _contacts;

        public NoteContact()
        {
            _contacts = new List<Contact>();
        }

        public void AddListContact(List<Contact> contacts)
        {
            _contacts.AddRange(contacts);
        }

        public void AddContact(string name, string phoneNumber)
        {
            Contact contact = new Contact(name, phoneNumber);
            _contacts.Add(contact);
        }

        public List<GroupContact> GetAllSortContact(Language language)
        {
            _contacts.Sort();
            List<GroupContact> groupContactsOut = new List<GroupContact>();
            GroupContact groupOtherLanguage = new GroupContact { GroupName = "#" };
            GroupContact groupContactNumber = new GroupContact { GroupName = "0 - 9" };
            GroupContact tempGroupContact = new GroupContact();
            foreach (var contact in _contacts)
            {
                if (char.IsDigit(contact.Name[0]))
                {
                    groupContactNumber.AddContact(contact);
                    continue;
                }

                byte b = System.Text.Encoding.Default.GetBytes(contact.Name.ToLower())[0];
                if (language == Language.Ukrainian)
                {
                    if ((b >= 97) && (b <= 122))
                    {
                        groupOtherLanguage.AddContact(contact);
                        continue;
                    }
                }

                if (language == Language.English)
                {
                    if ((b < 97) || (b > 122))
                    {
                        groupOtherLanguage.AddContact(contact);
                        continue;
                    }
                }

                if (tempGroupContact.GroupName?[0] == contact.Name.ToUpper()[0])
                {
                    tempGroupContact.AddContact(contact);
                }
                else
                {
                    if (tempGroupContact.GroupName != null)
                    {
                        groupContactsOut.Add(tempGroupContact);
                    }

                    tempGroupContact = new GroupContact() { GroupName = contact.Name.ToUpper().Substring(0, 1) };
                    tempGroupContact.AddContact(contact);
                }
            }

            groupContactsOut.Add(tempGroupContact);
            groupContactsOut.Add(groupOtherLanguage);
            groupContactsOut.Add(groupContactNumber);
            return groupContactsOut;
        }
    }
}
