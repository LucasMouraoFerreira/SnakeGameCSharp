using System;
using System.Collections.Generic;
using System.Text;
using SnakeGame.Entities.Enum;

namespace SnakeGame.Entities
{
    class Snake : MapUnit
    {
       
        public Direction HeadDirection { get; set; }
        public Position PreviousPosition { get; set; }

        public Snake(Position position) : base(position)
        {

            HeadDirection = Direction.Left;
            PreviousPosition = position;
        }

        public void ChangeDirection(char newDirection)
        {

            if (newDirection == 'a')
            {
                HeadDirection = Direction.Left;
            }
            else if (newDirection == 'w')
            {
                HeadDirection = Direction.Up;
            }
            else if (newDirection == 's')
            {
                HeadDirection = Direction.Down;
            }
            else if (newDirection == 'd')
            {
                HeadDirection = Direction.Right;
            }

        }

        public void ChangeDirectionIfHitTheWall()
        {

            if (HeadDirection == Direction.Down)
            {
                HeadDirection = Direction.Left;
            }
            else if (HeadDirection == Direction.Up)
            {
                HeadDirection = Direction.Left;
            }
            else if (HeadDirection == Direction.Left)
            {
                HeadDirection = Direction.Up;
            }
            else if (HeadDirection == Direction.Right)
            {
                HeadDirection = Direction.Up;
            }
        }

    }
}
