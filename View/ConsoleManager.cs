using System;
using System.Collections.Generic;
using System.Text;
using SnakeGame.Controller;
using SnakeGame.Entities;
using SnakeGame.Entities.Enum;

namespace SnakeGame.View
{
    class ConsoleManager
    {
        public static void PrintGame(GameController gameController)
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = -1; i < (gameController.GameMap.NumberOfRows + 1); i++)
            {
                ConsoleColor aux1 = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write("  ");
                Console.BackgroundColor = aux1;
                for (int j = 0; j < (gameController.GameMap.NumberOfColumns + 1); j++)
                {
                    if (i == -1 || i == gameController.GameMap.NumberOfRows)
                    {
                        ConsoleColor aux = Console.BackgroundColor;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("  ");
                        Console.BackgroundColor = aux;
                    }
                    else if (j == gameController.GameMap.NumberOfColumns)
                    {
                        ConsoleColor aux = Console.BackgroundColor;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("  ");
                        Console.BackgroundColor = aux;
                    }
                    else
                    {
                        if (gameController.GameMap.MapUnits[i, j] == null)
                        {
                            Console.Write("  ");
                        }
                        else if (gameController.GameMap.MapUnits[i, j] is Bomb)
                        {
                            ConsoleColor aux = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("  ");
                            Console.BackgroundColor = aux;
                        }
                        else if (gameController.GameMap.MapUnits[i, j] is Fruit)
                        {
                            ConsoleColor aux = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.BackgroundColor = aux;
                        }
                        else if (gameController.GameMap.MapUnits[i, j] is Snake)
                        {
                            ConsoleColor auxi = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Black;
                            ConsoleColor aux = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("- ");
                            Console.BackgroundColor = aux;
                            Console.ForegroundColor = auxi;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("PONTOS: " + gameController.Pontos);
            
        }
    }
}
