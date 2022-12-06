using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ContactCreater
    {
        public static List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("Charley", "050445789"));
            contacts.Add(new Contact("Jason Statham", "77789446584"));
            contacts.Add(new Contact("Thomas", "050445789"));
            contacts.Add(new Contact("Санька Встанька", "0954465844"));
            contacts.Add(new Contact("Adam Smasher", "666"));
            contacts.Add(new Contact("099946584", "099946584"));
            contacts.Add(new Contact("Учитель", "09944684"));
            contacts.Add(new Contact("Vin Diesel", "099844658454"));
            contacts.Add(new Contact("Harry", "050446584"));
            contacts.Add(new Contact("Jack", "050446584"));
            contacts.Add(new Contact("892231", "892231"));
            contacts.Add(new Contact("Влад Кручений", "0504566584"));
            contacts.Add(new Contact("Keanu Charles Reeves", "07746658484"));
            contacts.Add(new Contact("Валентин", "0976596574"));
            contacts.Add(new Contact("Віталий 2220", "0986597488"));
            contacts.Add(new Contact("Panam Palmer", "0856597488"));
            contacts.Add(new Contact("Delamain", "0888888"));
            contacts.Add(new Contact("Олег Кидала", "09598678874"));
            contacts.Add(new Contact("Не бери трубку", "087865784"));
            return contacts;
        }
    }
}
