using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rd = new Random();
            Random rd1 = new Random();

            Console.WriteLine(rd.Next(40) + " "+ rd1.Next(40));
            
            

            
        }
    }
}
