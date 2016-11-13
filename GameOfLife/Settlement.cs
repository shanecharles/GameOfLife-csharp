namespace GameOfLife
{
    public class Settlement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Settlement()
        {
            
        }

        public Settlement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var settlement = obj as Settlement;
            if (settlement == null) return false;
            return X == settlement.X && Y == settlement.Y;
        }
    }
}
