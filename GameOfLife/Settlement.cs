using System.Collections.Generic;

namespace GameOfLife
{
    public class Settlement : IEqualityComparer<Settlement>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Settlement() {}

        public Settlement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            var hash = X.GetHashCode()*13 + Y.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            var settlement = obj as Settlement;
            if (settlement == null) return false;
            return X == settlement.X && Y == settlement.Y;
        }

        public bool Equals(Settlement x, Settlement y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Settlement obj)
        {
            return base.GetHashCode();
        }
    }
}
