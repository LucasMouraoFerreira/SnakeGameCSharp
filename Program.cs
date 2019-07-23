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
            for(int i = 0; i<10; i++)
            {
                ConsoleManager.PrintGame(gameController);
                char ch = Console.ReadKey(true).KeyChar;
                gameController.SnakeParts[0].ChangeDirection(ch);
                gameController.UpdateSnakePositions();
                if (gameController.GameOver)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    break;
                }

            }
        }
    }
}
