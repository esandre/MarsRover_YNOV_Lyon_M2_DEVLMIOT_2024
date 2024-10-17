namespace MarsRover;

public class Rover
{
    private readonly IPlanète _planète;

    public Orientation Orientation { get; }
    public int Y { get; }
    public int X { get; }

    public Rover(Orientation orientation, IPlanète planète, int positionX = 0, int positionY = 0)
    {
        _planète = planète;
        Orientation = orientation;
        var positionNormalisée = _planète.Normaliser(positionX, positionY);

        X = positionNormalisée.X;
        Y = positionNormalisée.Y;
    }

    public Rover Avancer()
    {
        var vecteurX = Orientation == Orientation.Nord ? 1 : Orientation == Orientation.Sud ? -1 : 0;
        var vecteurY = Orientation == Orientation.Est ? 1 : Orientation == Orientation.Ouest ? - 1 : 0;

        return new Rover(Orientation, _planète, X + vecteurX, Y + vecteurY);
    }

    public Rover Reculer() => TournerADroite().TournerADroite().Avancer().TournerADroite().TournerADroite();

    public Rover TournerADroite()
    {
        var orientationSuivante = Orientation.Nord;
        if(Orientation == Orientation.Nord) orientationSuivante = Orientation.Est;
        if(Orientation == Orientation.Est) orientationSuivante = Orientation.Sud;
        if(Orientation == Orientation.Sud) orientationSuivante = Orientation.Ouest;
        return new Rover(orientationSuivante, _planète, X, Y);
    }

    public Rover TournerAGauche() => TournerADroite().TournerADroite().TournerADroite();
}