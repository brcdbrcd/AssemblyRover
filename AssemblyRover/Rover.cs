using System.Collections.Generic;
using System.Text;

namespace AssemblyRover
{
    public class Rover
    {
        public Coordinate Coordinate { get; }
        private StringBuilder PathBuilder { get; }
        public List<Coordinate> PickupCoordinates { get; private set; }

        public Rover(Coordinate _Coordinate)
        {
            Coordinate = _Coordinate;
            PathBuilder = new StringBuilder();
            PickupCoordinates = new List<Coordinate>();
        }

        public string GetPath()
        {
            return PathBuilder.ToString();
        }

        public bool GoToCoordinate(Coordinate TargetCoordinate)
        {
            while (!Coordinate.Equals(TargetCoordinate))
            {
                if (Coordinate.X < TargetCoordinate.X)
                {
                    Coordinate.X++;
                    AddToPath(RoverAction.MoveEast);
                }
                else if (Coordinate.X > TargetCoordinate.X)
                {
                    Coordinate.X--;
                    AddToPath(RoverAction.MoveWest);
                }
                if (Coordinate.Y < TargetCoordinate.Y)
                {
                    Coordinate.Y++;
                    AddToPath(RoverAction.MoveNorth);
                }
                else if (Coordinate.Y > TargetCoordinate.Y)
                {
                    Coordinate.Y--;
                    AddToPath(RoverAction.MoveSouth);
                }
            }
            AddToPath(RoverAction.PickComponent);
            PickupCoordinates.Add(TargetCoordinate);
            return true;
        }

        private void AddToPath(RoverAction action)
        {
            PathBuilder.Append((char)action);
        }
    }
}
