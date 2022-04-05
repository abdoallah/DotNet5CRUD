using System;

namespace PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number");
            int Number;
            Number = int.Parse(Console.ReadLine());
            int d = 0;
            for(int i=1; i<=Number;i++)
            {
                if (Number % i == 0)
                {
                    d++;
                }
               
            } 
            if(d==2)
                    Console.WriteLine("prime");
                else
                    Console.WriteLine("not prime");
        }
    }
}
