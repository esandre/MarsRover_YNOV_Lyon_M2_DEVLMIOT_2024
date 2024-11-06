using MarsRover.Rover;
using MarsRover.Topologie;

namespace MarsRover.Test.Utilities;

internal class RoverSpy : IRover
{
    private readonly IRover _behavior;

    public RoverSpy(IRover behavior)
    {
        _behavior = behavior;
        _allReceivedCommands = [];
    }

    private RoverSpy(IRover behavior, IList<char> alreadyReceivedCommands)
    {
        _behavior = behavior;
        _allReceivedCommands = alreadyReceivedCommands;
    }

    public IRover Avancer()
    {
        _allReceivedCommands.Add('A');
        return new RoverSpy(_behavior.Avancer(), _allReceivedCommands);
    }

    public IRover Reculer()
    {
        _allReceivedCommands.Add('R');
        return new RoverSpy(_behavior.Avancer(), _allReceivedCommands);
    }

    public IRover TournerADroite()
    {
        _allReceivedCommands.Add('D');
        return new RoverSpy(_behavior.Avancer(), _allReceivedCommands);
    }

    public IRover TournerAGauche()
    {
        _allReceivedCommands.Add('G');
        return new RoverSpy(_behavior.Avancer(), _allReceivedCommands);
    }

    public Orientation Orientation => _behavior.Orientation;
    public int Y => _behavior.Y;
    public int X => _behavior.X;

    private readonly IList<char> _allReceivedCommands;
    public string AllReceivedCommands => new(_allReceivedCommands.ToArray());
}