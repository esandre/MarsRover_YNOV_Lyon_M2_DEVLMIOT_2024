namespace MarsRover;

public static class AjoutObstacleExtensions
{
    public static IPlanète AjouterObstacle(this IPlanète planète, Obstacle obstacle)
    {
        return new PlanèteAvecObstacle(planète, obstacle);
    }
}