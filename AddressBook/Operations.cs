using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBook
{
    public class Operations
    {
        List<Contacts> listcontacts = new List<Contacts>();//list declaration to store the contact details
        List<Contacts> listcontacts2 = new List<Contacts>();
        Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();//Dictionary for the multiple address books
        Dictionary<string, Contacts> resultAddBook = new Dictionary<string, Contacts>();
        public void Add(int num)//add method to add the contacts
        {          
            for (int i = 0; i < num ; i++)
            {
                Console.Write("Enter First Name : ");
                string first_Name = Console.ReadLine();
                Console.Write("Enter Last Name : ");
                string last_Name = Console.ReadLine();
                Console.Write("Enter Address : ");
                string address = Console.ReadLine();
                Console.Write("Enter City Name : ");
                string city = Console.ReadLine();
                Console.Write("Enter State Name : ");
                string state = Console.ReadLine();
                Console.Write("Enter Zip Code : ");
                double zip = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Phone No. : ");
                double phone_No = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter E-mail ID : ");
                string email = Console.ReadLine();
                //adding the details in list

                listcontacts.Add(new Contacts()
                {
                    first_Name = first_Name,
                    last_Name = last_Name,
                    address = address,
                    city = city,
                    state = state,
                    zip = zip,
                    phone_No = phone_No,
                    email = email
                });
            }
        }
        
        public void Print()//Uniqe method to check the repeated Contact
        {
            for (int i = 0; i < listcontacts.Count; i++)
            {
                Contacts contact = listcontacts[i];

                if (!addressBook.ContainsKey(contact.first_Name))//if condition to check the key is present or not
                {
                    addressBook.Add(contact.first_Name, contact);//if not the add into the addressbook
                }
                // else
                // {
                //     Console.WriteLine("This Name {0} is already there", contact.first_Name);
                // }
            }                     
            foreach (var i in addressBook)//print the contact
            {
                Console.WriteLine("First Name :::: " + i.Key );
                Console.WriteLine("Last Name : " + i.Value.last_Name);
                Console.WriteLine("Address : " + i.Value.address);
                Console.WriteLine("City Name : " + i.Value.city);
                Console.WriteLine("State Name : " + i.Value.state);
                Console.WriteLine("Zip Code : " + i.Value.zip);
                Console.WriteLine("Phone No. : " + i.Value.phone_No);
                Console.WriteLine("Email ID : " + i.Value.email);            
            }
        }
        //Edit() method for Edit the Contacts
        public void Edit(string name,string f_name,string l_name,string add)//parameters given by the user
        {
            int index = -1;
            for(int i = 0; i <listcontacts.Count; i++)//for loop to check the name is present or not
            {
                if(listcontacts[i].first_Name == name)
                {
                    index = i;//If name is Present, index is chenged by the position of matched first_name
                }
            }
            if(index >= 0)
            {
                var editContact = listcontacts[index];
                editContact.first_Name = f_name;
                editContact.last_Name = l_name;
                editContact.address = add;
                listcontacts[index] = editContact;
                Console.WriteLine("The Data of {0} is Edited ", name);
            }
            else
            {
                Console.WriteLine("This Name is Not in List ");
            }
        }
        //Delete() method for Deleting the Contacts
        public void Delete(string f_name)//First Name is passed into method to check the contact
        {
            int index = -1;
            for (int i = 0; i < listcontacts.Count; i++)
            {
                if (listcontacts[i].first_Name == f_name)
                {
                    index = i;
                }
            }
            if (index >= 0)
            {
                listcontacts.RemoveAt(index);//Remove the contact 
                Console.WriteLine("The Data of {0} is Deleted ",f_name);
            }
            else
            {
                Console.WriteLine("This Name is Not in List ");
            }
        }
        /// <summary>
        /// SearchContactLambda() method to find and print the persons having entered city ans stste names
        /// </summary>
        /// <param name="cityName">City Name to find the Persons</param>
        /// <param name="statename">State Name to find Persons</param>
        public void SearchContactLambda(string cityName,string statename)
        {          
            listcontacts2 = listcontacts.FindAll(x => (x.city == cityName || x.state == statename));//Lambda Expression

            foreach (Contacts i in listcontacts2)
            {
                Console.WriteLine("First Name : "+i.first_Name);               
            }
        }
        
    }
}
