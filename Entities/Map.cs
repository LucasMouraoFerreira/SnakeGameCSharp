using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Entities
{
    class Map
    {
        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }
        public MapUnit[,] MapUnits { get; set; }

        public Map(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            MapUnits = new MapUnit[NumberOfRows, NumberOfColumns];
        }

        public void AddUnit(MapUnit mapUnit)
        {
            MapUnits[mapUnit.UnitPosition.Row, mapUnit.UnitPosition.Column] = mapUnit;
        }

        public void RemoveUnit(Position unitPosition)
        {
            MapUnits[unitPosition.Row, unitPosition.Column] = null;
        }
    }
}
