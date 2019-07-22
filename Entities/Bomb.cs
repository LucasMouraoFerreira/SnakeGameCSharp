using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Entities
{
    class Bomb : MapUnit
    {
        public int AliveTimeSeconds { get; private set; }

        public Bomb(Position position) : base(position)
        {
            AliveTimeSeconds = 7;
        }
    }
}
