using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System;

namespace AddressBookSystem
{
    public class FileIO
    {
        public static void WriteToFile(AddressBook addressBook,string bookName)
        {
            try
            {
                using(Stream stream = File.Open($"{Directory.GetCurrentDirectory()}\\AddressBooks\\Binary\\{bookName}.dat",FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream,addressBook);
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static AddressBook ReadFromFile(string bookName)
        {
            AddressBook addressBook;
            using(Stream stream = File.Open($"{Directory.GetCurrentDirectory()}\\AddressBooks\\Binary\\{bookName}.dat",FileMode.Open))
            {
                BinaryFormatter bin = new  BinaryFormatter();
                addressBook = (AddressBook)bin.Deserialize(stream);
            }
            return addressBook;
        }
    }
}