namespace MarsRover;

internal class PlanèteAvecObstacle : IPlanète
{
    private readonly IPlanète _inner;

    public PlanèteAvecObstacle(IPlanète inner, Obstacle obstacle)
    {
        _inner = inner;
    }

    public (int X, int Y) Normaliser(int x, int y)
    {
        return _inner.Normaliser(x, y);
    }
}