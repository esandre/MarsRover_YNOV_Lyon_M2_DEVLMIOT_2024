using MarsRover.Communication;
using MarsRover.Rover;

namespace MarsRover.MissionControl;

public class MissionControl
{
    private readonly ICommandSender _commandSender;
    private IRover _roverContrôlé;

    public MissionControl(ICommandSender commandSender, IRover roverContrôlé)
    {
        _commandSender = commandSender;
        _roverContrôlé = roverContrôlé;
    }

    public RoverState Envoyer(char action)
    {
        _commandSender.SendAsync(action);

        _roverContrôlé = _roverContrôlé.Recevoir(action);
        return new RoverState(_roverContrôlé.X, _roverContrôlé.Y, _roverContrôlé.Orientation);
    }
}   