namespace MarsRover.Test.Utilities;

internal class RoverBuilder
{
    private Orientation _orientation = Orientation.Nord;

    public Rover Build()
    {
        return new Rover(_orientation, new PlanèteInfinie());
    }

    public RoverBuilder Orienté(Orientation orientation)
    {
        _orientation = orientation;
        return this;
    }
}