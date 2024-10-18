namespace MarsRover;

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
        => _inner.Normaliser(x, y) with { Libre = !_obstacle.Collisionne(x, y) };
}

public record Obstacle(int X, int Y)
{
    public bool Collisionne(int x, int y) => x == X && y == Y;
}