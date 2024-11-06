using MarsRover.Topologie;

namespace MarsRover.Rover;

public class Rover : IRover
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
        if (!positionNormalisée.Libre) throw new PositionObstruéeException();

        X = positionNormalisée.X;
        Y = positionNormalisée.Y;
    }

    public IRover Avancer()
    {
        var positionX = X + Orientation.VecteurX;
        var positionY = Y + Orientation.VecteurY;

        var positionNormalisée = _planète.Normaliser(positionX, positionY);

        return !positionNormalisée.Libre
            ? this
            : new Rover(Orientation, _planète, positionNormalisée.X, positionNormalisée.Y);
    }

    public IRover Reculer() => TournerADroite().TournerADroite().Avancer().TournerADroite().TournerADroite();

    public IRover TournerADroite() => new Rover(Orientation.RotationHoraire(), _planète, X, Y);

    public IRover TournerAGauche() => TournerADroite().TournerADroite().TournerADroite();
}