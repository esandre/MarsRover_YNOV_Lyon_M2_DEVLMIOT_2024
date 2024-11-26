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

    public static Orientation Sud { get; } = new('S', -1, 0);
    public static Orientation Nord { get; } = new('N', 1, 0);
    public static Orientation Est { get; } = new('E', 0, 1);
    public static Orientation Ouest { get; } = new('O', 0, -1);

    internal static Orientation Parse(char letter)
    {
        switch (letter)
        {
            case 'S':
                return Sud;
            case 'N':
                return Nord;
            case 'E':
                return Est;
            case 'O':
                return Ouest;
            default:
                throw new ArgumentOutOfRangeException();
        }
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