using MarsRover.Rover;
using MarsRover.Topologie;

namespace MarsRover;

public readonly record struct RoverState(int X, int Y, Orientation Orientation)
{
    public static RoverState FromRover(IRover rover) => new(rover.X, rover.Y, rover.Orientation);

    public static RoverState Parse(string representation)
    {
        var parts = representation.Split(',');
        if (parts.Length != 3) throw new FormatException();
        var x = int.Parse(parts[0]);
        var y = int.Parse(parts[1]);
        var orientation = Topologie.Orientation.Parse(parts[2].Single());

        return new RoverState(x, y, orientation);
    }

    public override string ToString() => $"{X},{Y},{Orientation}";
}