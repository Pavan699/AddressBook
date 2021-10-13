using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NLog;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBook
{
    /// <summary>
    /// Class to get Address Books and set into the dictionary
    /// </summary>
    public class Operations
    {
        //Logger to pass the message
        public readonly Logger logger = LogManager.GetCurrentClassLogger();

        List<Contacts> listcontacts = new List<Contacts>();//list declaration to store the contact details
        List<Contacts> listcontactsCity = new List<Contacts>();
        List<Contacts> listcontactsState = new List<Contacts>();
        Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();//Dictionary for the multiple address books

        public string FilePath = @"D:\VS .net\AddressBook\AddressBook\Records.txt";
        public string CSVFilePath = @"D:\VS .net\AddressBook\AddressBook\CsvFile.csv";
        public string jsonpath = @"D:\VS .net\AddressBook\AddressBook\ContactData.json";
        /// <summary>
        /// add method to add the contacts
        /// </summary>
        /// <param name="num"></param>
        public void Add(int num)
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
            logger.Info("Contact is Added");
        }
        /// <summary>
        /// Print method to Print the Contacts in the List Without Repeatation
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < listcontacts.Count; i++)
            {
                Contacts contact = listcontacts[i];

                if (addressBook.ContainsKey(contact.first_Name))//if condition to check the key is present or not
                {
                    Console.WriteLine("This Name {0} is already there", contact.first_Name);
                    logger.Error("Name Already Present");
                }
                else
                {       
                    addressBook.Add(contact.first_Name, contact);//if not the add into the addressbook
                }
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
            logger.Info("Contact is Printed");
        }
        /// <summary>
        /// Edit() method for Edit the Contacts
        /// </summary>
        /// <param name="name">To check the It is present in the List or not</param>
        /// <param name="f_name">Edit the First Name</param>
        /// <param name="l_name">Edit the Last name</param>
        /// <param name="add">Address to edit</param>        
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
                logger.Info("Contact is Edited");
            }
            else
            {
                Console.WriteLine("This Name is Not in List ");
                logger.Warn("User is Not Present");
            }
        }
        /// <summary>
        /// Delete() method for Deleting the Contacts
        /// </summary>
        /// <param name="f_name">To search the Name to delete</param>      
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
                logger.Info("Contact is Deleted");
            }
            else
            {
                Console.WriteLine("This Name is Not in List ");
                logger.Warn("Contact is Not in the list");
            }
        }
        /// <summary>
        /// SearchContactLambda() method to find and print the persons having entered city ans stste names
        /// </summary>
        /// <param name="cityName">City Name to find the Persons</param>
        /// <param name="statename">State Name to find Persons</param>
        public void SearchContactLambda(string cityName,string statename)
        {          
            listcontactsCity = listcontacts.FindAll(x => (x.city == cityName));//Lambda Expression to check the names in city

            foreach (Contacts i in listcontactsCity)
            {
                Console.WriteLine("Name present in {0} City is : {1}", cityName, i.first_Name);
                Console.WriteLine("Phone No. is : " + i.phone_No);
            }
            listcontactsState = listcontacts.FindAll(x => (x.state == statename));//Lambda Expression to check the Names in State
            foreach (Contacts i in listcontactsState)
            {
                Console.WriteLine("Name present in {0} State is : {1}", statename, i.first_Name);
                Console.WriteLine("Phone No. is : " + i.phone_No); 
            }
        }
        /// <summary>
        /// StreamWriteFile method to write the data
        /// </summary>
        public void StreamWriteFile()
        {
            if (File.Exists(FilePath))
            {
                //append the contacts in the file 
                using (StreamWriter streamWriter = File.AppendText(FilePath))
                {
                    foreach (Contacts person in listcontacts)
                    {
                        streamWriter.WriteLine("\nFirstName: " + person.first_Name);
                        streamWriter.WriteLine("LastName: " + person.last_Name);
                        streamWriter.WriteLine("Address: " + person.address);
                        streamWriter.WriteLine("City    : " + person.city);
                        streamWriter.WriteLine("State   : " + person.state);
                        streamWriter.WriteLine("ZipCode: " + person.zip);
                        streamWriter.WriteLine("PhoneNum: " + person.phone_No);
                        streamWriter.WriteLine("Email   : " + person.email);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("Data Added in to the File");
                logger.Info("Data Added in text File");
            }
        }
        /// <summary>
        /// Read the contacts in the file
        /// </summary>
        public void StreamReadFile()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader streamReader = File.OpenText(FilePath))
                {
                    String ContactDetails = "";
                    while ((ContactDetails = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine((ContactDetails));
                    }
                }
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
            logger.Info("user Read the data");
        }
        /// <summary>
        /// Write the file using csv helper
        /// </summary>     
        public void WriteContactsCsv()
        {

            //open the stream file in write mode
            using (StreamWriter stream = new StreamWriter(CSVFilePath))
            // open csv file in write mode
            using (CsvWriter csvWriter = new CsvWriter(stream, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(listcontacts);
            }
            Console.WriteLine("\nData line added to CSV file...");

            ReadContactsCSV();
            logger.Info("CSV data Write");
        }
        /// <summary>
        /// read the file using csv helper
        /// </summary>
        public void ReadContactsCSV()
        {
            //open the stream file in write mode       
            using (StreamReader reader = new StreamReader(CSVFilePath))
            using (var read = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var contacts = read.GetRecords<Contacts>().ToList();
                foreach (Contacts contact in contacts)
                {
                    Console.WriteLine(contact.first_Name + "," + contact.last_Name + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.zip + "," + contact.phone_No + "," + contact.email);
                }
            }
        }
        /// <summary>
        /// method to write the data in JSON file
        /// </summary>
        /// <param name="keyValues"></param>
        public void JsonWrite()
        {
            if (File.Exists(jsonpath))
            {
                string data = JsonConvert.SerializeObject(addressBook);
                using (StreamWriter sw = new StreamWriter(jsonpath))
                {
                    sw.WriteLine(data);
                }
            }
        }
    }
}
