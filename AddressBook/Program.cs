using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Program");
            Operations op = new Operations();
            int count = 0;

            while (count <= 30)
            {
                Console.WriteLine("1:Add Contact  2:Print Contact  3:Edit Contact  4:Delete Contact");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        op.Add();
                        break;
                    case 2:
                        op.Print();
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name,Last Name and Address To Edit :");
                        string fname = Console.ReadLine();
                        string lname = Console.ReadLine();
                        string add = Console.ReadLine();
                        op.Edit(fname,lname,add);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name To Delete:");
                        string f_name = Console.ReadLine();
                        op.Delete(f_name);
                        break;
                    default:
                        Console.WriteLine("Wrong Input :)");
                        break;
                }
                count++;
            }
            Console.WriteLine("Count of Operations Performed On Address Book is : " + count);
        }
    }
}
