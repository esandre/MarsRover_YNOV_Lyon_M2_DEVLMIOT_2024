using MarsRover.Topologie;

namespace MarsRover.MissionControl;

public class MissionControl
{
    public MissionControl(Rover.Rover roverContrôlé)
    {
    }

    public RoverState AvancerRover()
    {
        return new RoverState(1, 0, Orientation.Nord);
    }
}   