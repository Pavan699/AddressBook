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
    }
}
