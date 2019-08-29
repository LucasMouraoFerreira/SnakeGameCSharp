using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SnakeGame.Entities;
using SnakeGame.Entities.Enum;
using SnakeGame.View;


namespace SnakeGame.Controller
{
    class GameController
    {
        public bool GameOver { get; private set; }
        public Map GameMap { get; private set; }
        public List<Snake> SnakeParts { get; private set; }
        public List<Fruit> Fruits { get; private set; }
        public List<Bomb> Bombs { get; private set; }
        public int Pontos { get; private set; }
        public int FruitAliveTime { get; private set; }
        public int BombAliveTime { get; private set; }


        public GameController(int numberOfRows, int numberOfColumns)
        {
            GameMap = new Map(numberOfRows, numberOfColumns);
            GameOver = false;
            Pontos = 0;
            SnakeParts = new List<Snake>();
            Fruits = new List<Fruit>();
            Bombs = new List<Bomb>();
            FruitAliveTime = 5;
            BombAliveTime = 10;

            Position posHeadAux = new Position(numberOfRows / 2, numberOfColumns / 2);
            Position posTailAux = new Position(numberOfRows / 2, (numberOfColumns / 2) + 1);
            
            Snake snakeHead = new Snake(posHeadAux);
            Snake snakeTail = new Snake(posTailAux);
            
            SnakeParts.Add(snakeHead);
            SnakeParts.Add(snakeTail);
            GameMap.AddUnit(snakeHead);
            GameMap.AddUnit(snakeTail);
            
        }

        public void TaskUpdateAndPrint()
        {
            var taskUpdateAndPrint = Task.Run(async delegate
            {
                while (!GameOver)
                {
                    
                    UpdateSnakePositions();
                    ConsoleManager.PrintGame(this);
                    await Task.Delay(200);
                }
                Console.Clear();
                Console.WriteLine("GAME OVER!!");
                Console.WriteLine("PONTOS: "+ Pontos);
                Console.WriteLine("Aperte alguma tecla para finalizar a aplicação");
            });
        }

        public void TaskAddFruits()
        {
            var taskAddFruits = Task.Run(async delegate
            {
                while (!GameOver)
                {
                    GenerateFruits();
                    await Task.Delay(FruitAliveTime * 1000 + 7);
                }

            });
        }

        public void TaskAddBombs()
        {
            var taskAddBombs = Task.Run(async delegate
            {
                while (!GameOver)
                {
                    GenerateBombs();
                    await Task.Delay(BombAliveTime * 1000 + 111);
                }

            });
        }

        public void GenerateFruits()
        {
            foreach(Fruit fruit in Fruits)
            {
                if (!(GameMap.MapUnits[fruit.UnitPosition.Row, fruit.UnitPosition.Column] is Snake))
                {
                    GameMap.RemoveUnit(fruit.UnitPosition);
                }
            }
            Fruits.Clear();

            Random random = new Random();
            int aux = random.Next(100);
            if(aux < 60) // place one fruit
            {
                bool canPut = false;
                while (!canPut)
                {
                    Random rdRow = new Random();
                    Random rdColumn = new Random();
                    int auxRow = rdRow.Next(GameMap.NumberOfRows);
                    int auxColumn = rdColumn.Next(GameMap.NumberOfColumns);
                    if (GameMap.MapUnits[auxRow, auxColumn] == null &&
                        (((auxRow - SnakeParts[0].UnitPosition.Row) < -2) || ((auxRow - SnakeParts[0].UnitPosition.Row) > 2)
                        || ((auxColumn - SnakeParts[0].UnitPosition.Column) < -2) || ((auxColumn - SnakeParts[0].UnitPosition.Column) > 2)))
                    {
                        GameMap.AddUnit(new Fruit(new Position(auxRow, auxColumn)));
                        Fruits.Add(new Fruit(new Position(auxRow, auxColumn)));
                        canPut = true;
                    }
                }
            }
            else // place two fruits
            {
                bool canPut = false;
                while (!canPut)
                {
                    Random rdRow1 = new Random();
                    Random rdColumn1 = new Random();
                    Random rdRow2 = new Random();
                    Random rdColumn2 = new Random();
                    int auxRow1 = rdRow1.Next(GameMap.NumberOfRows);
                    int auxColumn1 = rdColumn1.Next(GameMap.NumberOfColumns);
                    int auxRow2 = rdRow2.Next(GameMap.NumberOfRows);
                    int auxColumn2 = rdColumn2.Next(GameMap.NumberOfColumns);
                    if ((auxRow1 != auxRow2 || auxColumn1 != auxColumn2) &&
                        GameMap.MapUnits[auxRow1, auxColumn1] == null && GameMap.MapUnits[auxRow2, auxColumn2] == null &&
                        (((auxRow1 - SnakeParts[0].UnitPosition.Row) < -2) || ((auxRow1 - SnakeParts[0].UnitPosition.Row) > 2)
                        || ((auxColumn1 - SnakeParts[0].UnitPosition.Column) < -2) || ((auxColumn1 - SnakeParts[0].UnitPosition.Column) > 2))
                        && (((auxRow2 - SnakeParts[0].UnitPosition.Row) < -2) || ((auxRow2 - SnakeParts[0].UnitPosition.Row) > 2)
                        || ((auxColumn2 - SnakeParts[0].UnitPosition.Column) < -2) || ((auxColumn2 - SnakeParts[0].UnitPosition.Column) > 2)))
                    {
                        GameMap.AddUnit(new Fruit(new Position(auxRow1, auxColumn1)));
                        Fruits.Add(new Fruit(new Position(auxRow1, auxColumn1)));
                        GameMap.AddUnit(new Fruit(new Position(auxRow2, auxColumn2)));
                        Fruits.Add(new Fruit(new Position(auxRow2, auxColumn2)));
                        canPut = true;
                    }
                }
            }
        }

        public void GenerateBombs()
        {
            foreach (Bomb bomb in Bombs)
            {
                if (!(GameMap.MapUnits[bomb.UnitPosition.Row, bomb.UnitPosition.Column] is Snake))
                {
                    GameMap.RemoveUnit(bomb.UnitPosition);
                }
            }
            Bombs.Clear();

            Random random = new Random();
            int aux = random.Next(100);
            if (aux < 60) // place one Bomb
            {
                bool canPut = false;
                while (!canPut)
                {
                    Random rdRow = new Random();
                    Random rdColumn = new Random();
                    int auxRow = rdRow.Next(GameMap.NumberOfRows);
                    int auxColumn = rdColumn.Next(GameMap.NumberOfColumns);
                    if (GameMap.MapUnits[auxRow, auxColumn] == null &&
                        (((auxRow - SnakeParts[0].UnitPosition.Row) < -2) || ((auxRow - SnakeParts[0].UnitPosition.Row) > 2)
                        || ((auxColumn - SnakeParts[0].UnitPosition.Column) < -2) || ((auxColumn - SnakeParts[0].UnitPosition.Column) > 2)))
                    {
                        GameMap.AddUnit(new Bomb(new Position(auxRow, auxColumn)));
                        Bombs.Add(new Bomb(new Position(auxRow, auxColumn)));
                        canPut = true;
                    }
                }
            }
            else // place two bombs
            {
                bool canPut = false;
                while (!canPut)
                {
                    Random rdRow1 = new Random();
                    Random rdColumn1 = new Random();
                    Random rdRow2 = new Random();
                    Random rdColumn2 = new Random();
                    int auxRow1 = rdRow1.Next(GameMap.NumberOfRows);
                    int auxColumn1 = rdColumn1.Next(GameMap.NumberOfColumns);
                    int auxRow2 = rdRow2.Next(GameMap.NumberOfRows);
                    int auxColumn2 = rdColumn2.Next(GameMap.NumberOfColumns);
                    if ((auxRow1 != auxRow2 || auxColumn1 != auxColumn2) &&
                        GameMap.MapUnits[auxRow1, auxColumn1] == null && GameMap.MapUnits[auxRow2, auxColumn2] == null &&
                        (((auxRow1 - SnakeParts[0].UnitPosition.Row) < -2) || ((auxRow1 - SnakeParts[0].UnitPosition.Row) > 2)
                        || ((auxColumn1 - SnakeParts[0].UnitPosition.Column) < -2) || ((auxColumn1 - SnakeParts[0].UnitPosition.Column) > 2))
                        && (((auxRow2 - SnakeParts[0].UnitPosition.Row) < -2) || ((auxRow2 - SnakeParts[0].UnitPosition.Row) > 2)
                        || ((auxColumn2 - SnakeParts[0].UnitPosition.Column) < -2) || ((auxColumn2 - SnakeParts[0].UnitPosition.Column) > 2)))
                    {
                        GameMap.AddUnit(new Bomb(new Position(auxRow1, auxColumn1)));
                        Bombs.Add(new Bomb(new Position(auxRow1, auxColumn1)));
                        GameMap.AddUnit(new Bomb(new Position(auxRow2, auxColumn2)));
                        Bombs.Add(new Bomb(new Position(auxRow2, auxColumn2)));
                        canPut = true;
                    }
                }
            }
        }

        public void UpdateSnakePositions()
        {
            Snake snakeHead = SnakeParts[0];
            Snake snakeTail = SnakeParts[SnakeParts.Count - 1];

            if (snakeHead.HeadDirection == Direction.Left)
            {
                if (snakeHead.UnitPosition.Column == 0 && !(snakeHead.UnitPosition.Row == 0))
                {
                    snakeHead.HeadDirection = Direction.Up;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row -1, snakeHead.UnitPosition.Column);
                }
                else if (snakeHead.UnitPosition.Column == 0 && snakeHead.UnitPosition.Row == 0)
                {
                    snakeHead.HeadDirection = Direction.Down;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row + 1, snakeHead.UnitPosition.Column);
                }
                else
                {
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column - 1);
                }

                if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Bomb)
                {
                    GameOver = true;
                }
                else if ((GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Snake) && !(snakeHead.UnitPosition == snakeTail.UnitPosition))
                {
                    GameOver = true;
                }
                else if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Fruit)
                {
                    Pontos++;
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    Fruits.RemoveAll(x => x.UnitPosition == snakeHead.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count - 1; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    SnakeParts.Insert(SnakeParts.Count - 1, new Snake((SnakeParts[SnakeParts.Count - 2].PreviousPosition)));
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
                else
                {
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    GameMap.RemoveUnit(snakeTail.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
            }
            else if (snakeHead.HeadDirection == Direction.Right)
            {
                if (snakeHead.UnitPosition.Column == (GameMap.NumberOfColumns - 1) && snakeHead.UnitPosition.Row != 0)
                {
                    snakeHead.HeadDirection = Direction.Up;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row - 1, snakeHead.UnitPosition.Column);
                }
                else if (snakeHead.UnitPosition.Column == (GameMap.NumberOfColumns - 1) && snakeHead.UnitPosition.Row == 0)
                {
                    snakeHead.HeadDirection = Direction.Down;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row + 1, snakeHead.UnitPosition.Column);
                }
                else
                {
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column + 1);
                }

                if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Bomb)
                {
                    GameOver = true;
                }
                else if ((GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Snake) && !(snakeHead.UnitPosition == snakeTail.UnitPosition))
                {
                    GameOver = true;
                }
                else if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Fruit)
                {
                    Pontos++;
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    Fruits.RemoveAll(x => x.UnitPosition == snakeHead.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count - 1; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    SnakeParts.Insert(SnakeParts.Count - 1, new Snake((SnakeParts[SnakeParts.Count - 2].PreviousPosition)));
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
                else
                {
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    GameMap.RemoveUnit(snakeTail.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
            }
            else if (snakeHead.HeadDirection == Direction.Up)
            {
                if (snakeHead.UnitPosition.Row == 0 && snakeHead.UnitPosition.Column != 0)
                {
                    snakeHead.HeadDirection = Direction.Left;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column - 1);
                }
                else if (snakeHead.UnitPosition.Row == 0 && snakeHead.UnitPosition.Column == 0)
                {
                    snakeHead.HeadDirection = Direction.Right;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column + 1);
                }
                else
                {
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row - 1, snakeHead.UnitPosition.Column);
                }

                if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Bomb)
                {
                    GameOver = true;
                }
                else if ((GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Snake) && !(snakeHead.UnitPosition == snakeTail.UnitPosition))
                {
                    GameOver = true;
                }
                else if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Fruit)
                {
                    Pontos++;
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    Fruits.RemoveAll(x => x.UnitPosition == snakeHead.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count - 1; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    SnakeParts.Insert(SnakeParts.Count - 1, new Snake((SnakeParts[SnakeParts.Count - 2].PreviousPosition)));
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
                else
                {
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    GameMap.RemoveUnit(snakeTail.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
            }
            else if (snakeHead.HeadDirection == Direction.Down)
            {
                if (snakeHead.UnitPosition.Row == (GameMap.NumberOfRows -1) && snakeHead.UnitPosition.Column != 0)
                {
                    snakeHead.HeadDirection = Direction.Left;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column - 1);
                }
                else if(snakeHead.UnitPosition.Row == (GameMap.NumberOfRows - 1) && snakeHead.UnitPosition.Column == 0)
                {
                    snakeHead.HeadDirection = Direction.Right;
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column + 1);
                }
                else
                {
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row + 1, snakeHead.UnitPosition.Column);
                }

                if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Bomb)
                {
                    GameOver = true;
                }
                else if ((GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Snake) && !(snakeHead.UnitPosition == snakeTail.UnitPosition))
                {
                    GameOver = true;
                }
                else if (GameMap.MapUnits[snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column] is Fruit)
                {
                    Pontos++;
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    Fruits.RemoveAll(x => x.UnitPosition == snakeHead.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count - 1; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    SnakeParts.Insert(SnakeParts.Count - 1, new Snake((SnakeParts[SnakeParts.Count - 2].PreviousPosition)));
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
                else
                {
                    GameMap.AddUnit(new Snake(snakeHead.UnitPosition));
                    GameMap.RemoveUnit(snakeTail.UnitPosition);
                    SnakeParts[0] = snakeHead;
                    for (int i = 1; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].UnitPosition = SnakeParts[i - 1].PreviousPosition;

                    }
                    for (int i = 0; i < SnakeParts.Count; i++)
                    {
                        SnakeParts[i].PreviousPosition = SnakeParts[i].UnitPosition;
                    }
                }
            }
        }
    }
}
