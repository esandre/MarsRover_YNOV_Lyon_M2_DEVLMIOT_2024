namespace MarsRover.Topologie;

internal class PlanèteAvecObstacle : IPlanète
{
    private readonly IPlanète _inner;
    private readonly Obstacle _obstacle;

    public PlanèteAvecObstacle(IPlanète inner, Obstacle obstacle)
    {
        _inner = inner;

        var coordonnéesObstacleNormalisée = inner.Normaliser(obstacle.X, obstacle.Y);
        _obstacle = new Obstacle(coordonnéesObstacleNormalisée.X, coordonnéesObstacleNormalisée.Y);
    }

    public (int X, int Y, bool Libre) Normaliser(int x, int y)
    {
        var innerValue = _inner.Normaliser(x, y);
        var collisionne = _obstacle.Collisionne(innerValue.X, innerValue.Y);
        if (collisionne) return innerValue with { Libre = false };
        return innerValue;
    }
}

public record Obstacle(int X, int Y)
{
    public bool Collisionne(int x, int y) => x == X && y == Y;
}