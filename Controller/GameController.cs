using System;
using System.Collections.Generic;
using System.Text;
using SnakeGame.Entities;
using SnakeGame.Entities.Enum;

namespace SnakeGame.Controller
{
    class GameController
    {
        public bool GameOver { get; set; }
        public Map GameMap { get; set; }
        public List<Snake> SnakeParts { get; set; }
        public HashSet<Fruit> Fruits { get; set; }
        public HashSet<Bomb> Bombs { get; set; }
        public int Pontos { get; private set; }

        public GameController(int numberOfRows, int numberOfColumns)
        {
            GameMap = new Map(numberOfRows, numberOfColumns);
            GameOver = false;
            Pontos = 0;
            SnakeParts = new List<Snake>();
            Fruits = new HashSet<Fruit>();
            Bombs = new HashSet<Bomb>();
        } 


    }
}
