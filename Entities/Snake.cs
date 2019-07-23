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
    }
}
