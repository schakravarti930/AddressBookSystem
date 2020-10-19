using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public static Dictionary<string, AddressBook> AddressBookMap = new Dictionary<string, AddressBook>();
        public static Dictionary<Contact, string> CitywiseContactMap = new Dictionary<Contact, string>();
        public static Dictionary<Contact, string> StatewiseContactMap = new Dictionary<Contact, string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            int choice;
            string name;
            do
            {
                Console.WriteLine("\nMenu : \n 1.Add New Address Book \n 2.Work On Existing Address Book \n 3.View Contact By City or State \n 4.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Name of Address Book");
                        name = Console.ReadLine();
                        AddressBookMap.Add(name, new AddressBook());
                        break;
                    case 2:
                        Console.WriteLine("Enter the Name of Address Book you wish to Work On");
                        name = Console.ReadLine();
                        AddressBook addressBook = AddressBookMap[name];
                        FillAddressBook(addressBook);
                        break;
                    case 3:
                        ViewPersonByCityOrState();
                        break;
                }
            } while (choice != 3);
         }

        public static void SetContactDetails(Contact contact)
        {
            Console.WriteLine("Enter the First Name");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter the City Name");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter the State Name");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter the zip code");
            contact.Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number");
            contact.PhoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the email address");
            contact.Email = Console.ReadLine();
            CitywiseContactMap[contact] = contact.City;
            StatewiseContactMap[contact] = contact.State;
        }

        public static void FillAddressBook(AddressBook addressBook)
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
                        SetContactDetails(contact);
                        addressBook.AddContact(contact);
                        break;
                    case 2:
                        Console.WriteLine("Enter the Phone Number of Contact you wish to Edit");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        int index = addressBook.FindByPhoneNum(phoneNumber);
                        if (index == -1)
                        {
                            Console.WriteLine("No Contact Exists With Following Phone Number");
                            continue;
                        }
                        else
                        {
                            Contact contact2 = new Contact();
                            SetContactDetails(contact2);
                            addressBook.ContactList[index] = contact2;
                            Console.WriteLine("Contact Updated Successfully");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the First Name of Contact you wish to delete");
                        string fname = Console.ReadLine();
                        int idx = addressBook.FindByFirstName(fname);
                        if (idx == -1)
                        {
                            Console.WriteLine("No Contact Exists with Following First Name");
                            continue;
                        }
                        else
                        {
                            addressBook.DeleteContact(idx);
                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        break;
                }
            } while (choice != 0);
        }
        public static void ViewPersonByCityOrState()
        {
            int choice;
            Console.WriteLine("1.View Person Contact By City \n2.View Person Contact By State");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the City Name");
                    string city = Console.ReadLine();
                    List<Contact> contactListInGivenCity = new List<Contact>();
                    foreach(KeyValuePair<Contact,string> kvp in CitywiseContactMap)
                    {
                        if (kvp.Value.Equals(city))
                            contactListInGivenCity.Add(kvp.Key);
                    }
                    foreach(Contact contact in contactListInGivenCity)
                    {
                        Console.WriteLine(contact);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the State Name");
                    string state = Console.ReadLine();
                    List<Contact> contactListInGivenState = new List<Contact>();
                    foreach (KeyValuePair<Contact, string> kvp in StatewiseContactMap)
                    {
                        if (kvp.Value.Equals(state))
                            contactListInGivenState.Add(kvp.Key);
                    }
                    foreach (Contact contact in contactListInGivenState)
                    {
                        Console.WriteLine(contact);
                    }
                    break;
            }
        }
    }
}
