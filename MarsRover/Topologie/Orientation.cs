namespace MarsRover.Topologie;

public class Orientation
{
    private readonly char _representation;

    private Orientation(char representation, int vecteurX, int vecteurY)
    {
        _representation = representation;
        VecteurX = vecteurX;
        VecteurY = vecteurY;
    }

    public static Orientation Sud { get; } = new('S', 0, -1);
    public static Orientation Nord { get; } = new('N', 0, 1);
    public static Orientation Est { get; } = new('E', 1, 0);
    public static Orientation Ouest { get; } = new('O', -1, 0);

    internal static Orientation Parse(char letter)
    {
        return letter switch
        {
            'S' => Sud,
            'N' => Nord,
            'E' => Est,
            'O' => Ouest,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    internal int VecteurX { get; }
    internal int VecteurY { get; }

    internal Orientation RotationHoraire() =>
        _representation switch
        {
            'S' => Ouest,
            'N' => Est,
            'E' => Sud,
            'O' => Nord,
            _ => throw new IndexOutOfRangeException()
        };

    public override string ToString() => _representation.ToString();
}