namespace MarsRover;

public class Rover
{
    public Orientation Orientation { get; }

    public Rover(Orientation orientation, int positionX = 0, int positionY = 0)
    {
        Orientation = orientation;
        X = positionX;
        Y = positionY;
    }

    public Rover Avancer()
    {
        var vecteurX = Orientation == Orientation.Nord ? 1 : Orientation == Orientation.Sud ? -1 : 0;
        var vecteurY = Orientation == Orientation.Est ? 1 : Orientation == Orientation.Ouest ? - 1 : 0;
        return new Rover(Orientation, X + vecteurX, Y + vecteurY);
    }

    public int Y { get; }

    public int X { get; }

    public Rover Reculer()
    {
        var vecteurX = Orientation == Orientation.Nord ? -1 : Orientation == Orientation.Sud ? 1 : 0;
        return new Rover(Orientation, X + vecteurX);
    }

    public Rover TournerADroite()
    {
        var orientationSuivate = Orientation.Nord;
        if(Orientation == Orientation.Nord) orientationSuivate = Orientation.Est;
        if(Orientation == Orientation.Est) orientationSuivate = Orientation.Sud;
        if(Orientation == Orientation.Sud) orientationSuivate = Orientation.Ouest;
        return new Rover(orientationSuivate);
    }
}