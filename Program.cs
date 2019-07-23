using System;
using SnakeGame.Controller;
using SnakeGame.View;

namespace SnakeGame
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                GameController gameController = new GameController(15, 15);

                ConsoleManager.PrintGame(gameController);
                Console.WriteLine("Para mover use:   \"w\" ");
                Console.WriteLine("              \"a\" \"s\" \"d\"");
                Console.WriteLine("Colete as frutas vermelhas!!");
                Console.WriteLine("Evite as bombas azuis!!");
                Console.WriteLine("PRESSIONE QUALQUER TECLA PARA COMEÇAR!");
                Console.ReadKey();

                gameController.TaskUpdateAndPrint();
                gameController.TaskAddFruits();
                gameController.TaskAddBombs();

                while (!gameController.GameOver)
                {
                    char ch = Console.ReadKey(true).KeyChar;
                    gameController.SnakeParts[0].ChangeDirection(ch);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
