namespace MarsRover;

public class Rover
{
    private Orientation Orientation { get; }

    public Rover(Orientation orientation, int positionX = 0)
    {
        Orientation = orientation;
        X = positionX;
    }

    public Rover Avancer()
    {
        var vecteurX = Orientation == Orientation.Nord ? 1 : Orientation == Orientation.Sud ? -1 : 0;
        return new Rover(Orientation, X + vecteurX) { Y = Y+1 };
    }

    public int Y { get; set; }

    public int X { get; }

    public Rover Reculer()
    {
        var vecteurX = Orientation == Orientation.Nord ? -1 : Orientation == Orientation.Sud ? 1 : 0;
        return new Rover(Orientation, X + vecteurX);
    }
}