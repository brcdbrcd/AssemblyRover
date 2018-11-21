namespace AssemblyRover
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }

        public override bool Equals(object CoordinateToCompare)
        {
            Coordinate TargetCoordinate = (Coordinate)CoordinateToCompare;
            if (X == TargetCoordinate.X && Y == TargetCoordinate.Y)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + X.GetHashCode();
            hash = (hash * 7) + Y.GetHashCode();
            return hash;
        }
    }
}
