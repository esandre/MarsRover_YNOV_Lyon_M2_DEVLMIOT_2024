namespace MarsRover;

internal class PlanèteAvecObstacle : IPlanète
{
    private readonly IPlanète _inner;
    private readonly Obstacle _obstacle;

    public PlanèteAvecObstacle(IPlanète inner, Obstacle obstacle)
    {
        _inner = inner;
        _obstacle = obstacle;
    }

    public (int X, int Y, bool Libre) Normaliser(int x, int y)
    {
        // TODO : potentiel bug de normalisation
        return _inner.Normaliser(x, y) with { Libre = !_obstacle.Collisionne(x, y) };
    }
}

public record Obstacle(int X, int Y)
{
    public bool Collisionne(int x, int y)
    {
        return x == X && y == Y;
    }
}