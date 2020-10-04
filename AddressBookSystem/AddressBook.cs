using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public List<Contact> ContactList;
        public AddressBook()
        {
            this.ContactList = new List<Contact>();
        }
        //Add Contact to Address Book
        public void AddContact(Contact contactObj)
        {
            this.ContactList.Add(contactObj);
        }
        //Find Contact Object By Mobile Number
        public int FindByPhoneNum(long phoneNumber)
        {
            return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(phoneNumber));
        }
    }
}
