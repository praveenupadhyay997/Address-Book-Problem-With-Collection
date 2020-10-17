using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    /// <summary>
    /// This is the higher order directory class containing value like dictionary and key input like address book
    /// </summary>
    /// <seealso cref="AddressBookProblem.IAddressBook" />
    class AddressBookDetail : IAddressBook
    {
        string addressBookName;
        const int ADD_CONTACT = 1;
        const int EDIT_CONTACT = 2;
        const int DELETE_CONTACT = 3;
        const int GET_ALL_CONTACTS =4;
        public Dictionary<string, AddressBook> addressBookList = new Dictionary<string, AddressBook>();

        public AddressBook GetAddressBook()
        {
            Console.WriteLine("\nEnter name of Address Book to be accessed or to be added");
            addressBookName = Console.ReadLine().ToLower();

            //search for address book in dictionary
            if (addressBookList.ContainsKey(addressBookName))
            {
                Console.WriteLine("\nAddressBook Identified");
                return addressBookList[addressBookName];
            }

            //Offer to create a address book if not found in dictionary
            else
            {
                Console.WriteLine("\nAddress book not found. Type y to create a new address book or n to exit");
                if ((Console.ReadLine() == "y" || Console.ReadLine() == "Y"))
                {
                    AddressBook addressBook = new AddressBook(addressBookName);
                    addressBookList.Add(addressBookName, addressBook);
                    Console.WriteLine("\nNew Address Book Created");
                    return addressBookList[addressBookName];
                }
                else
                {
                    Console.WriteLine("\nAction Aborted");
                    return null;
                }


            }
        }


        /// <summary>
        /// Adds the or access address book.
        /// </summary>
        public void AddOrAccessAddressBook()
        {
            AddressBook addressBook = GetAddressBook();

            if (addressBook == null)
            {
                Console.WriteLine("Action aborted");
                return;
            }

            Outer:
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome to the {0}'s Address Book", addressBookName.ToUpper());
            Console.WriteLine("******************************************");
            Console.WriteLine("1. Create A New Contact");
            Console.WriteLine("2. Edit a contact");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Display Stored Contact");
            Console.WriteLine("Press any Key to Exit!!!!!!!");

            switch (Convert.ToInt32(Console.ReadLine().ToLower()))
            {
                case ADD_CONTACT:

                    addressBook.AddContact();
                    break;

                case EDIT_CONTACT:

                    addressBook.editContactDetails();
                    break;

                case GET_ALL_CONTACTS:

                    addressBook.displayDetails();
                    break;

                case DELETE_CONTACT:

                    addressBook.deleteDetails();
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Exiting address book");
                    return;
            }

            Console.WriteLine("\nType y to continue in same address Book or any other key to exit");
            if (!(Console.ReadLine().ToLower() == "y"))
            {
                return;
            }
            else
                goto Outer;
        }

        /// <summary>
        /// Views all address books.
        /// </summary>
        public void ViewAllAddressBooks()
        {
            if (addressBookList.Count == 0)
                Console.WriteLine("No record found");
            else
            {
                Console.WriteLine("\nThe namesof address books available are :");
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookList)
                    Console.WriteLine(keyValuePair.Key);
            }
        }

        /// <summary>
        /// Deletes the address book.
        /// </summary>
        public void DeleteAddressBook()
        {
            if (addressBookList.Count == 0)
                Console.WriteLine("No record in the Address Book. Enter some record when directed.");
            else
            {
                Console.WriteLine("\nEnter the name of address book to be deleted ==>>");
                addressBookName = Console.ReadLine();
                //search for address book with given name
                try
                {
                    addressBookList.Remove(addressBookName);
                    Console.WriteLine("Address book was deleted with success");                   
                }
                catch
                {
                    Console.WriteLine("Address book not found");
                }
            }
        }
    }
}
