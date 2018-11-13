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

        public bool Equals(Coordinate CoordinateToCompare)
        {
            if (X == CoordinateToCompare.X && Y == CoordinateToCompare.Y)
            {
                return true;
            }
            return false;
        }
    }
}
