using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Entities
{
    class Fruit : MapUnit
    {
        public int AliveTimeSeconds { get; private set; }

        public Fruit(Position position) : base(position)
        {
            AliveTimeSeconds = 5;
        }
    }
}
