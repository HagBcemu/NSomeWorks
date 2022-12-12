using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSomeWorks
{
    class ContactLINQ
    {
        private List<Contact> _contacts;
        public ContactLINQ(List<Contact> contacts)
        {
            _contacts = new List<Contact>();
            _contacts.AddRange(contacts);
        }

        public List<Contact> GetAllContact()
        {
            return _contacts;
        }

        public List<Contact> WhereContact(string whereString)
        {
            var listWhere = from contact in _contacts
                     where contact.FirstName == whereString
                     select contact;
            return listWhere.ToList<Contact>();
        }

        public List<Contact> SelectContact(string selectString)
        {
            var listWhere = from contact in _contacts
                            where contact.FirstName == selectString
                            select new Contact(contact.FirstName + " modyfied by select", contact.Number);
            return listWhere.ToList();
        }

        public Contact FirstContact(string firstString)
        {
            var listFirsContact = _contacts?.Where(x => x.Number.ToString().StartsWith(firstString)).FirstOrDefault();
            return listFirsContact;
        }

        public bool ContainsContact(string containsName)
        {
            bool contains = _contacts.Contains(_contacts.Where(x => x.FirstName == containsName)?.FirstOrDefault());
            return contains;
        }

        public int CountSubNumber(string firstString)
        {
            var countName = _contacts.Where(x => x.Number.ToString().Contains(firstString)).Count();
            return countName;
        }

        public List<Contact> SkipTakeReverse(string stringTakeSkip)
        {
            string[] stringArray = stringTakeSkip.Split("/");
            List<Contact> contains = new List<Contact>();
            if (stringArray.Length == 2)
            {
                int number1 = 0;
                int number2 = 0;
                bool parse1 = int.TryParse(stringArray[0], out number1);
                bool parse2 = int.TryParse(stringArray[1], out number2);
                if (parse1 && parse2)
                {
                    contains = _contacts.Skip(number1).Take(number2).Reverse().ToList();
                }
            }

            return contains;
        }
    }
}
