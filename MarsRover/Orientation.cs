namespace MarsRover;

public class Orientation
{
    private readonly string _representation;

    private Orientation(string representation)
    {
        _representation = representation;
    }

    public static Orientation Sud { get; } = new("S");
    public static Orientation Nord { get; } = new("N");
    public static Orientation Est { get; } = new("E");
    public static Orientation Ouest { get; } = new("O");

    public override string ToString()
    {
        return _representation;
    }
}