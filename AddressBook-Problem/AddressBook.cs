// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AddressBook
    {
        /// List Collection used to cover the domain of contact addition inside an address book
        public List<ContactDetails> contactList = new List<ContactDetails>();
        /// Field storing the name of the address book
        public string nameOfAddressBook = "";
        //Delegate declared to define a lambda function for cehcking duplicacy
        public delegate bool CheckForDuplicate(string firstName, string lastName);

        /// <summary>
        /// Contact detail variables
        /// </summary>
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public long zip;
        public long phoneNumber;
        public string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public AddressBook(string nameOfAddressBook)
        {
            this.nameOfAddressBook = nameOfAddressBook;
        }

        public void AddContact()
        {
            // Flag to check the willingness to enter more contact details
            char ch = 'y';
            while (ch == 'y' || ch == 'Y')
            {
                Console.WriteLine("\nEnter The First Name = ");
                firstName = Console.ReadLine();

                Console.WriteLine("\nEnter The Last Name =");
                lastName = Console.ReadLine();

                //Lambda Function defined to check duplicacy of the contact
                CheckForDuplicate duplicate = (firstName, lastName) =>
                {
                    foreach (var contactObj in this.contactList)
                    {
                        if ((firstName == contactObj.firstName) && (lastName == contactObj.secondName))
                        {
                            Console.WriteLine("Same Entry is present in the contact list");
                            return true;
                        }
                    }
                    return false;
                };
                //Invoking the lambda function for checking duplicacy
                bool prescenceDuplicate = duplicate.Invoke(firstName, lastName);
                //Ternary statement for indicating the prescence
                Console.WriteLine(prescenceDuplicate ? "Already Present" : "Absent");
                // UC-7 Checking for duplicate of the contacts inside the address book on basis of the name
                if (prescenceDuplicate)
                {
                    Console.WriteLine("No duplicate entry allowed");
                }
                else
                {
                    Console.WriteLine("\nEnter The Address =");
                    address = Console.ReadLine();

                    Console.WriteLine("\nEnter The City =");
                    city = Console.ReadLine();

                    Console.WriteLine("\nEnter The State =");
                    state = Console.ReadLine();

                    Console.WriteLine("\nEnter the Zip code");
                    zip = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("\nEnter The phone number = ");
                    phoneNumber = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("\nEnter The Email of Contact");
                    email = Console.ReadLine();

                    // Adding the details once validated for not a duplicate entry
                    ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
                    this.contactList.Add(addNewContact);
                    Console.WriteLine("\nContact Was added to the contact list");
                }
                Console.WriteLine("Press y or Y to enter more Data OR Press any other word key to exit....");
                ch = Convert.ToChar(Console.ReadLine());
            }

        }

        /// <summary>
        /// Edits the contact details.
        /// </summary>
        public void EditContactDetails()
        {
            int index = 0;

            Console.WriteLine("Enter the first name of person whose data to be modified=");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the second name of person whose data to be modified=");
            lastName = Console.ReadLine();

            

            foreach (var contactObj in this.contactList)
            {

                if ((firstName == contactObj.firstName) && (lastName == contactObj.secondName))
                {
                    break;
                }
                index++;
            }
            Console.WriteLine("Enter the modified data===>");

            Console.WriteLine("Enter the first name=");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the second name=");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter the address=");
            address = Console.ReadLine();
            Console.WriteLine("Enter the City=");
            city = Console.ReadLine();
            Console.WriteLine("Enter the State=");
            state = Console.ReadLine();
            Console.WriteLine("Enter the zip code=");
            zip = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the Phone number=");
            phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the emailId=");
            email = Console.ReadLine();

            contactList[index].firstName = firstName;
            contactList[index].secondName = lastName;
            contactList[index].address = address;
            contactList[index].city = city;
            contactList[index].state = state;
            contactList[index].zip = zip;
            contactList[index].phoneNumber = phoneNumber;
            contactList[index].emailId = email;
        }

        public void DeleteDetails()
        {
            Console.WriteLine("Enter the first name of person whose data to be modified=");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the second name of person whose data to be modified=");
            lastName = Console.ReadLine();

            int index = 0;
            foreach (var contactObj in contactList)
            {

                if ((firstName == contactObj.firstName) && (lastName == contactObj.secondName))
                {
                    break;
                }
                index++;
            }
            contactList.RemoveAt(index);
        }

        /// <summary>
        /// Displays the details.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine("First Name  ----- Second Name ----- Addres ----- City ----- State ----- Zip ----- Phone Number ----- Email Id");
            foreach (var contactObj in this.contactList)
            {
                Console.WriteLine(contactObj.firstName + "            " + contactObj.secondName + "            " + contactObj.address + "       " + contactObj.city + "      " + contactObj.state + "       " + contactObj.zip + "       " + contactObj.phoneNumber + "        " + contactObj.emailId);
            }
        }      
    }
}

