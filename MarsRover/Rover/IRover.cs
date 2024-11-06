using MarsRover.Topologie;

namespace MarsRover.Rover;

public interface IRover
{
    IRover Avancer();
    IRover Reculer();
    IRover TournerADroite();
    IRover TournerAGauche();

    Orientation Orientation { get; }
    int Y { get; }
    int X { get; }
}