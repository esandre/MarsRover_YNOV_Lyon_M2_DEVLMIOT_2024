using MarsRover.Rover;

namespace MarsRover.MissionControl;

public class MissionControl
{
    private Rover.Rover _roverContrôlé;

    public MissionControl(Rover.Rover roverContrôlé)
    {
        _roverContrôlé = roverContrôlé;
    }

    public RoverState Envoyer(char action)
    {
        _roverContrôlé = _roverContrôlé.Recevoir(action);
        return new RoverState(_roverContrôlé.X, _roverContrôlé.Y, _roverContrôlé.Orientation);
    }
}   