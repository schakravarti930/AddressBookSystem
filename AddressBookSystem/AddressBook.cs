using System;
using System.Collections.Generic;
using System.Linq;
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
            if (this.ContactList.Find(e => e.Equals(contactObj)) != null)
                Console.WriteLine("The Contact Already Exists! Try Again.");
            else
                this.ContactList.Add(contactObj);
        }
        //Find Contact Object Index By Mobile Number
        public int FindByPhoneNum(long phoneNumber)
        {
            return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(phoneNumber));
        }
        //Find Contact Object Index By FirstName
        public int FindByFirstName(string firstName)
        {
            return this.ContactList.FindIndex(contact => contact.FirstName.Equals(firstName));
        }
        //Delete a Given Contact By Index
        public void DeleteContact(int index)
        {
            this.ContactList.RemoveAt(index);
        }
        public List<Contact> SortByFirstName()
        {
            return this.ContactList.OrderBy(contact => contact.FirstName).ToList();
        }
    }
}
