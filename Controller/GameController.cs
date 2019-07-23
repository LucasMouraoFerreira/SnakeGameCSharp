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

            Position posHeadAux = new Position(numberOfRows / 2, numberOfColumns / 2);
            Position posTailAux = new Position(numberOfRows / 2, (numberOfColumns / 2) + 1);
            
            Snake snakeHead = new Snake(posHeadAux);
            Snake snakeTail = new Snake(posTailAux);
            
            SnakeParts.Add(snakeHead);
            SnakeParts.Add(snakeTail);
            GameMap.AddUnit(snakeHead);
            GameMap.AddUnit(snakeTail);
            
        }


        public void UpdateSnakePositions()
        {
            Snake snakeHead = SnakeParts[0];
            Snake snakeTail = SnakeParts[SnakeParts.Count - 1];

            if (snakeHead.HeadDirection == Direction.Left)
            {
                if (snakeHead.UnitPosition.Column == 0)
                {
                    snakeHead.ChangeDirectionIfHitTheWall();
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
                if (snakeHead.UnitPosition.Column == (GameMap.NumberOfColumns - 1))
                {
                    snakeHead.ChangeDirectionIfHitTheWall();
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
                if (snakeHead.UnitPosition.Row == 0)
                {
                    snakeHead.ChangeDirectionIfHitTheWall();
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column - 1);
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
                if (snakeHead.UnitPosition.Row == (GameMap.NumberOfRows -1))
                {
                    snakeHead.ChangeDirectionIfHitTheWall();
                    snakeHead.UnitPosition = new Position(snakeHead.UnitPosition.Row, snakeHead.UnitPosition.Column-1);
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
