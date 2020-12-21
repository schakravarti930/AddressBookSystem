using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public static Dictionary<string, AddressBook> AddressBookMap = new Dictionary<string, AddressBook>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            int choice;
            string name;
            do
            {
                Console.WriteLine("\nMenu : \n 1.Add New Address Book \n 2.Work On Existing Address Book \n 3.View Contact By City or State \n4.Count by city \n 5.Save and Exit \n6.Exit");
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
                        foreach(Contact contact in ViewPersonByCityOrState())
                        {
                            System.Console.WriteLine(contact);
                            System.Console.WriteLine();
                        }
                        break;
                    case 4:
                        CountPersonByCityOrState();
                        break;
                    case 5:
                        foreach(KeyValuePair<string,AddressBook> kvp in AddressBookMap)
                        {
                            FileIO.WriteToFile(kvp.Value,kvp.Key);
                        }
                        break;
                }
            } while (choice != 6);
            // AddressBook book = FileIO.ReadFromFile("book");
            // foreach(Contact contact in book.ContactList)
            // {
            //     System.Console.WriteLine(contact);
            // }
         }
        public static List<Contact> ViewPersonByCityOrState()
        {
            Console.WriteLine("1.Get By City \n2.Get By State");
            int choice = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter the name of the place");
            string name = Console.ReadLine();

            List<Contact> contactListInGivenCity = new List<Contact>();
            foreach(KeyValuePair<string,AddressBook> kvp in AddressBookMap)
            {
                contactListInGivenCity.AddRange(kvp.Value.ContactList.FindAll(ChooseCityOrState(choice,name)));
            }
            return contactListInGivenCity;
        }
        public static void CountPersonByCityOrState()
        {
            int count = ViewPersonByCityOrState().Count;
            System.Console.WriteLine($"{count} contacts found");
        }
        public static Predicate<Contact> ChooseCityOrState(int choice,string name)
        {
            if(choice == 1)
            {
                return p => p.City.Equals(name);
            }
            else if(choice == 2)
            {
                return p => p.State.Equals(name);
            }
            else 
            {
                return null;
            }
        }
    }
}

