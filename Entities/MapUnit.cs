using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Entities
{
    class MapUnit
    {
        public Position UnitPosition { get; set; }

        public MapUnit(Position unitPosition)
        {
            UnitPosition = unitPosition;
        }

        public MapUnit(int row, int column)
        {
            UnitPosition = new Position(row, column);
        }
    }
}
