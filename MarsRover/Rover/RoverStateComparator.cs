namespace MarsRover.Rover;

internal class RoverStateComparator : IEqualityComparer<IRover>
{
    public bool Equals(IRover? first, IRover? second)
    {
        if (ReferenceEquals(first, second)) return true;
        if (ReferenceEquals(first, null)) return false;
        if (ReferenceEquals(second, null)) return false;
        if (first.GetType() != second.GetType()) return false;

        return first.Orientation.Equals(second.Orientation)
               && first.Y == second.Y
               && first.X == second.X;
    }

    public int GetHashCode(IRover obj) => HashCode.Combine(obj.Orientation, obj.Y, obj.X);
}