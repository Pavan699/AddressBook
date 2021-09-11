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
            op.Edit("pavan","NakATE","edtey73uha2");
            op.Print();
        }
    }
}
