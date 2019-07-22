using System;
using SnakeGame.Controller;
using SnakeGame.Entities;
using SnakeGame.View;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Random rd = new Random();
            Random rd1 = new Random();

            Console.WriteLine(rd.Next(40) + " "+ rd1.Next(40));*/
            GameController gameController = new GameController(15, 50);
            ConsoleManager.PrintGame(gameController);





        }
    }
}
