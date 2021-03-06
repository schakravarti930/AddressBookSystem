﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    [Serializable()]
    public class AddressBook 
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
        public List<Contact> SortByCity()
        {
            return this.ContactList.OrderBy(contact => contact.City).ToList();
        }
        public List<Contact> SortByState()
        {
            return this.ContactList.OrderBy(contact => contact.State).ToList();
        }
        public List<Contact> SortByZip() 
        {
            return this.ContactList.OrderBy(contact => contact.Zip).ToList();
        }
        public void FillAddressBook()
        {
            int choice;
            do
            {
                Console.WriteLine("\nMenu : \n1.Add Contact \n2.Edit Contact \n3.Delete Contact\n0.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Contact contact = new Contact();
                        contact.SetContactDetails();
                        this.AddContact(contact);
                        break;
                    case 2:
                        Console.WriteLine("Enter the Phone Number of Contact you wish to Edit");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        int index = this.FindByPhoneNum(phoneNumber);
                        if (index == -1)
                        {
                            Console.WriteLine("No Contact Exists With Following Phone Number");
                            continue;
                        }
                        else
                        {
                            Contact contact2 = new Contact();
                            contact2.SetContactDetails();
                            this.ContactList[index] = contact2;
                            Console.WriteLine("Contact Updated Successfully");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the First Name of Contact you wish to delete");
                        string fname = Console.ReadLine();
                        int idx = this.FindByFirstName(fname);
                        if (idx == -1)
                        {
                            Console.WriteLine("No Contact Exists with Following First Name");
                            continue;
                        }
                        else
                        {
                            this.DeleteContact(idx);
                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        break;
                }
            } while (choice != 0);
        }
    }
}
