using MarsRover.Rover;
using MarsRover.Topologie;

namespace MarsRover.Test.Utilities;

internal class RoverSpy : IRover
{
    public IRover Avancer()
    {
        LastReceivedCommand = 'A';
        return this;
    }

    public IRover Reculer()
    {
        LastReceivedCommand = 'R';
        return this;
    }

    public IRover TournerADroite()
    {
        LastReceivedCommand = 'D';
        return this;
    }

    public IRover TournerAGauche()
    {
        LastReceivedCommand = 'G';
        return this;
    }

    public Orientation Orientation { get; }
    public int Y { get; }
    public int X { get; }

    public char LastReceivedCommand { get; private set; }
}