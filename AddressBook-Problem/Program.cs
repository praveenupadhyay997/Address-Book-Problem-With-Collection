using System;
using System.Xml.Serialization;

namespace AddressBookProblem
{
    /// <summary>
    /// Interface for The Entire address book
    /// </summary>
    public interface IAddressBook
    {
        void AddOrAccessAddressBook();
        void ViewAllAddressBooks();
        void DeleteAddressBook();
    }
    class Program
    {
        static void Main(string[] args)
        {

            AddressBookDetail addressBookDetail = new AddressBookDetail();
            // Driving the Execution through menu guidation
            Outer:
            Console.WriteLine("***************************");
            Console.WriteLine("Welcome to the Address Book");
            Console.WriteLine("****************************");
            Console.WriteLine("1. Add or Access the Address Book");
            Console.WriteLine("2. Display the present address Books");
            Console.WriteLine("3. Delete the address book");
            Console.WriteLine("Press any other Key to Exit!!!!!!!");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBookDetail.AddOrAccessAddressBook();
                    Console.Clear();
                    break;

                case 2:
                    addressBookDetail.ViewAllAddressBooks();
                    Console.Clear();
                    break;

                case 3:
                    addressBookDetail.DeleteAddressBook();
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Enter the correct choice Please!!!!!!");
                    break;

            }
            goto Outer;

        }
    }
}
