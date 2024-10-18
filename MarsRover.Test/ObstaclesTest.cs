namespace MarsRover.Test;

public class ObstaclesTest
{
    [Fact]
    public void ObstacleSimple()
    {
        // ETANT DONNE un obstacle en 1, 0 sur une planète de taille 2
        var obstacle = new Obstacle(1, 0);
        var planète = new PlanèteToroïdale(2)
            .AjouterObstacle(obstacle);

        // ET un Rover orienté Nord en 0,0 sur une planète de taille 2
        var roverInitial = new Rover(Orientation.Nord, planète, 0, 0);

        // QUAND le Rover avance
        var roverFinal = roverInitial.Avancer();

        // ALORS il conserve sa position
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
        Assert.Equal(roverInitial.Orientation, roverFinal.Orientation);
    }
}