namespace MarsRover;

public class Orientation
{
    private readonly string _representation;

    private Orientation(string representation, int vecteurX, int vecteurY)
    {
        _representation = representation;
        VecteurX = vecteurX;
        VecteurY = vecteurY;
    }

    public static Orientation Sud { get; } = new("S", -1, 0);
    public static Orientation Nord { get; } = new("N", 1, 0);
    public static Orientation Est { get; } = new("E", 0, 1);
    public static Orientation Ouest { get; } = new("O", 0, -1);

    internal int VecteurX { get; }
    internal int VecteurY { get; }

    internal Orientation RotationHoraire() =>
        _representation switch
        {
            "S" => Ouest,
            "N" => Est,
            "E" => Sud,
            "O" => Nord,
            _ => throw new IndexOutOfRangeException()
        };

    public override string ToString()
    {
        return _representation;
    }
}