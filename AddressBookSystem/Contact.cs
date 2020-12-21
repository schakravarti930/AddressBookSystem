using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    [Serializable()]
    public class Contact
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
            return this.FirstName.Equals(contact.FirstName) && this.LastName.Equals(contact.LastName);
        }
        public override string ToString()
        {
            return $"Name : {FirstName} {LastName} \nAddress : {Address} \nCity : {City} \nState : {State} \nZip : {Zip} \nPhone : {PhoneNumber} \nEmail : {Email}";
        }
        public void SetContactDetails()
        {
            Console.WriteLine("Enter the First Name");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            Address = Console.ReadLine();
            Console.WriteLine("Enter the City Name");
            City = Console.ReadLine();
            Console.WriteLine("Enter the State Name");
            State = Console.ReadLine();
            Console.WriteLine("Enter the zip code");
            Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number");
            PhoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the email address");
            Email = Console.ReadLine();
        }
    }
}
