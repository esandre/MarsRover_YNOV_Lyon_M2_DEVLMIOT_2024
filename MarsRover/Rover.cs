namespace MarsRover;

public class Rover
{
    public Orientation Orientation { get; private set; }

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

    public Rover TournerADroite()
    {
        return this;
    }
}