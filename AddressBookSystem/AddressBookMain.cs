using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome To Address Book Program");
            Console.WriteLine("Menu : \n1.Add Contact");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Contact contact = new Contact();
                    setContactDetails(contact);
                    addressBook.AddContact(contact);
                    break;
            }
            Console.WriteLine(addressBook.ContactList.Count);
        }
        public static void setContactDetails(Contact contact)
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
        }
    }
}
