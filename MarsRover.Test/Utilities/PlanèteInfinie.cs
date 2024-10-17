namespace MarsRover.Test.Utilities;

internal class PlanèteInfinie : IPlanète
{
    public (int X, int Y) Normaliser(int x, int y)
    {
        return (x, y);
    }
}