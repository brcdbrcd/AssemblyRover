namespace AssemblyRover
{
    public class PickUpEngine : IPickUpEngine
    {
        public bool PickUpComponents(Grid grid)
        {
            foreach (Component component in grid.ComponentList)
            {
                if (!grid.Rover.GoToCoordinate(component.Coordinate))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
