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
        X = positionX;
        Y = positionY;
    }

    public Rover Avancer()
    {
        var vecteurX = Orientation == Orientation.Nord ? 1 : Orientation == Orientation.Sud ? -1 : 0;
        var vecteurY = Orientation == Orientation.Est ? 1 : Orientation == Orientation.Ouest ? - 1 : 0;

        var positionProjetéeX = X + vecteurX;
        var positionProjetéeY = Y + vecteurY;

        var positionNormalisée = _planète.Normaliser(positionProjetéeX, positionProjetéeY);

        return new Rover(Orientation, _planète, positionNormalisée.X, positionNormalisée.Y);
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