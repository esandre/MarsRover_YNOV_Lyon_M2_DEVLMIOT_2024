using MarsRover.Rover;
using MarsRover.Topologie;

namespace MarsRover;

public readonly record struct RoverState(int X, int Y, Orientation Orientation)
{
    public static RoverState FromRover(IRover rover) => new(rover.X, rover.Y, rover.Orientation);
}