using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public List<Contact> ContactList;
        public AddressBookMain()
        {
            this.ContactList = new List<Contact>();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
        }
    }
}
