using System;

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

            while (count <= 30)
            {
                Console.WriteLine("1:Add Contact  2:Print Contact  3:Edit Contact  4:Delete Contact 5:Exit");
                int choice = Convert.ToInt32(Console.ReadLine());//variable for taking choice from the user
                //Switch Case for doing Operations
                switch(choice)
                {
                    case 1:
                        op.Add();//Calling Add() method to add contact in Address-Book
                        break;
                    case 2:
                        op.Print();//To Print Contact in Address-Book
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name,Last Name and Address To Edit :");
                        string fname = Console.ReadLine();
                        string lname = Console.ReadLine();
                        string add = Console.ReadLine();
                        op.Edit(fname,lname,add);//Edit the Contact by passing parameters from users in the method
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name To Delete:");
                        string f_name = Console.ReadLine();
                        op.Delete(f_name);//Delete the Contact by passing First Name from users
                        break;
                    default:
                        Console.WriteLine("Wrong Input :)");//Default Condition For Exit the while loop
                        break;
                }
                count++;
            }
            Console.WriteLine("Count of Operations Performed On Address Book is : " + count);//print operations count
        }
    }
}
