using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Program");
            Operations op = new Operations();
            op.Add();
            op.Print();
        }
    }
}
