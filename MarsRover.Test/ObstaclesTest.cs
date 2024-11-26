using MarsRover.Rover;
using MarsRover.Test.Utilities;
using MarsRover.Topologie;

namespace MarsRover.Test;

public class ObstaclesTest
{
    [Fact]
    public void ObstacleSimple()
    {
        // ETANT DONNE un obstacle en 1,0
        var obstacle = new Obstacle(1, 0);

        // ET un Rover orienté Nord en 0,0
        var roverInitial = new RoverBuilder()
            .Orienté(Orientation.Nord)
            .Positionné(0, 0)
            .AjouterObstacleSurPlanète(obstacle)
            .Build();

        // QUAND le Rover avance
        var roverFinal = roverInitial.Avancer();

        // ALORS il conserve sa position
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
        Assert.Equal(roverInitial.Orientation, roverFinal.Orientation);
    }

    [Fact]
    public void PlusieursObstacles()
    {
        // ETANT DONNE un Rover en 1,1
        // ET 4 obstacles l'entourant
        var roverInitial = new RoverBuilder()
            .Positionné(1, 1)
            .AjouterObstacleSurPlanète(new Obstacle(1, 0))
            .AjouterObstacleSurPlanète(new Obstacle(0, 1))
            .AjouterObstacleSurPlanète(new Obstacle(2, 1))
            .AjouterObstacleSurPlanète(new Obstacle(1, 2))
            .Build();

        // QUAND le Rover avance quelque soit la direction
        IRover[] roversAux4Directions =
        [
            roverInitial,
            roverInitial.TournerADroite(),
            roverInitial.TournerADroite().TournerADroite(),
            roverInitial.TournerADroite().TournerADroite().TournerADroite()
        ];

        roversAux4Directions = roversAux4Directions.Select(rover => rover.Avancer()).ToArray();

        // ALORS il conserve sa position
        foreach (var rover in roversAux4Directions)
        {
            Assert.Equal(roverInitial.X, rover.X);
            Assert.Equal(roverInitial.Y, rover.Y);
        }
    }

    [Fact]
    // Ce teste vise à se blinder contre la non-normalisation des coordonnées d'un obstacles avant comparaison.
    public void ObstacleToroïdal()
    {
        // ETANT DONNE un obstacle en 2,2 sur une planète toroïdale de taille 2
        var obstacle = new Obstacle(2, 2);
        var planète = new PlanèteToroïdale(2)
            .AjouterObstacle(obstacle);

        // ET un Rover orienté Nord en 0,0
        var builder = new RoverBuilder()
            .Orienté(Orientation.Nord)
            .Positionné(0, 0)
            .SurLaPlanète(planète);

        // QUAND le Rover atterrit
        void Act() => builder.Build();

        // ALORS une exception est lancée
        Assert.Throws<PositionObstruéeException>(Act);
    }

    [Fact]
    public void AterrissageObstrué()
    {
        // ETANT DONNE un obstacle en 0, 0
        var obstacle = new Obstacle(0, 0);

        // ET un Rover atterrissant en 0,0
        var builder = new RoverBuilder()
            .Positionné(0, 0)
            .AjouterObstacleSurPlanète(obstacle);

        // QUAND le Rover atterrit
        void Act() => builder.Build();

        // ALORS une exception est lancée
        Assert.Throws<PositionObstruéeException>(Act);
    }
}