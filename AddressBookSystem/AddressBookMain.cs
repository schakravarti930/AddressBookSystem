using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public static Dictionary<string, AddressBook> AddressBookMap = new Dictionary<string, AddressBook>();
        public static Dictionary<string, List<Contact>> CityWiseContacts = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> StateWiseContacts = new Dictionary<string, List<Contact>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            int choice;
            string name;
            do
            {
                Console.WriteLine("\nMenu : \n 1.Add New Address Book \n 2.Work On Existing Address Book \n3.City Or State Wise Search \n4.Exit");
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
                        addressBook.FillAddressBook();
                        break;
                    case 3:
                        Console.WriteLine("1.Search By City \n2.Search By State");
                        int input = Convert.ToInt32(Console.ReadLine());
                        if(input == 1)
                        {
                            Console.WriteLine("Enter the city Name");
                            string city = Console.ReadLine();
                            GetContactByCity(city).ForEach(contact => Console.WriteLine(contact));
                        }
                        else
                        {
                            Console.WriteLine("Enter the state Name");
                            string state = Console.ReadLine();
                            GetContactByState(state).ForEach(contact => Console.WriteLine(contact));
                        }
                        break;
                }
            } while (choice != 4);
         }
        public static List<Contact> GetContactByCity(string city)
        {
            return CityWiseContacts[city];
        }
        public static List<Contact> GetContactByState(string state)
        {
            return StateWiseContacts[state];
        }
    }
}
