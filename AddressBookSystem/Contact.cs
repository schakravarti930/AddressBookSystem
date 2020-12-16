using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public override bool Equals(object obj)
        {
            Contact contact = obj as Contact;
            if (obj == null)
                return false;
            return contact.FirstName.Equals(this.FirstName) && contact.LastName.Equals(this.LastName);
        }
        public void SetContactDetails()
        {
            Console.WriteLine("Enter the First Name");
            this.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            this.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            this.Address = Console.ReadLine();
            Console.WriteLine("Enter the City Name");
            this.City = Console.ReadLine();
            Console.WriteLine("Enter the State Name");
            this.State = Console.ReadLine();
            Console.WriteLine("Enter the zip code");
            this.Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number");
            this.PhoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the email address");
            this.Email = Console.ReadLine();
            /*List<Contact> citywise = CityWiseContacts[this.City];
            citywise.Add(this);
            CityWiseContacts.Add(this.City, citywise);
            List<Contact> statewise = StateWiseContacts[this.State];
            statewise.Add(this);
            StateWiseContacts.Add(this.State, statewise);*/
        }
    }
}
