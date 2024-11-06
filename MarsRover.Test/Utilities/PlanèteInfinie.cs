using MarsRover.Topologie;

namespace MarsRover.Test.Utilities;

internal class PlanèteInfinie : IPlanète
{
    public (int X, int Y, bool Libre) Normaliser(int x, int y)
    {
        return (x, y, true);
    }
}