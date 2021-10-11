using System;
using NLog;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title Of the Program
            Console.WriteLine("Address Book Program");
            //Object for the Operations Class
            Operations op = new Operations();
            int count = 0;//Counter To count the operations Done in Address Book
            int defcount = 0;//counter to break the while loop

            while (defcount == 0)
            {
                Console.WriteLine("1:Add Contact  2:Print Contact  3:Edit Contact  4:Delete Contact 5:FindContact 6.FileWriter 7.FileReader 8.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());//variable for taking choice from the user
                //Switch Case for doing Operations
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter How many Contacts You want to enter : ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        op.Add(num);//Calling Add() method to add contact in Address-Book
                        count++;
                        break;
                    case 2:
                        op.Print();//To Print Contact in Address-Book
                        count++;
                        break;
                    case 3:
                        Console.WriteLine("Enter Check Name,First Name,Last Name and Address To Edit :");
                        string name = Console.ReadLine();
                        string fname = Console.ReadLine();
                        string lname = Console.ReadLine();
                        string add = Console.ReadLine();
                        op.Edit(name, fname, lname, add);//Edit the Contact by passing parameters from users in the method
                        count++;
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name To Delete:");
                        string f_name = Console.ReadLine();
                        op.Delete(f_name);//Delete the Contact by passing First Name from users
                        count++;
                        break;
                    case 5:
                        Console.Write("Enter City-Name And State-Name to find the Persons : ");
                        string cname = Console.ReadLine();
                        string sname = Console.ReadLine();
                        op.SearchContactLambda(cname, sname);
                        count++;
                        break;
                    case 6:
                        op.StreamWriteFile();
                        count++;
                        break;
                    case 7:
                        op.StreamReadFile();
                        count++;
                        break;
                    case 8:
                        op.WriteContactsCsv();
                        count++;
                        break;
                    default:
                        Console.WriteLine("End");//Default Condition For Exit the while loop
                        defcount++;
                        break;
                }
            }
            Console.WriteLine("Count of Operations Performed On Address Book is : " + count);//print operations count
        }
    }
}
