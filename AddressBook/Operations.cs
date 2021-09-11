using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    public class Operations
    {
        List<Contacts> listcontacts = new List<Contacts>();
        public void Add()
        {
            Console.Write("Enter First Name : ");
            string first_Name =Console.ReadLine();
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
            }) ;
        }
        public void Print()
        {
            foreach(var i in listcontacts)
            {
                Console.WriteLine("First Name : " + i.first_Name);
                Console.WriteLine("Last Name : " + i.last_Name);
                Console.WriteLine("Address : " + i.address);
                Console.WriteLine("City Name : " + i.city);
                Console.WriteLine("State Name : " + i.state);
                Console.WriteLine("Zip Code : " + i.zip);
                Console.WriteLine("Phone No. : " + i.phone_No);
                Console.WriteLine("Email ID : " + i.email);
            }
        }
        public void Edit(string f_name,string l_name,string add)
        {
            int index = -1;
            for(int i = 0; i <listcontacts.Count; i++)
            {
                if(listcontacts[i].first_Name == f_name)
                {
                    index = i;
                }
            }
            if(index >=0)
            {
                var editContact = listcontacts[index];                
                editContact.last_Name = l_name;
                editContact.address = add;
                listcontacts[index] = editContact;
                Console.WriteLine("The Data of {0} is Edited ", f_name);
            }
            else
            {
                Console.WriteLine("This Name is Not in List ");
            }
        }
        public void Delete(string f_name)
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
                listcontacts.RemoveAt(index);
                Console.WriteLine("The Data of {0} is Deleted ",f_name);
            }
            else
            {
                Console.WriteLine("This Name is Not in List ");
            }
        }
    }
}
