﻿namespace MarsRover.Test.Utilities;

internal class RoverBuilder
{
    private Orientation _orientation = Orientation.Nord;
    private readonly List<Obstacle> _obstacles = [];
    private int _x;
    private int _y;

    public Rover Build()
    {
        IPlanète planète = new PlanèteInfinie();
        foreach (var obstacle in _obstacles)
            planète = planète.AjouterObstacle(obstacle);

        return new Rover(_orientation, planète, _x, _y);
    }

    public RoverBuilder Orienté(Orientation orientation)
    {
        _orientation = orientation;
        return this;
    }

    public RoverBuilder Positionné(int x, int y)
    {
        _x = x;
        _y = y;
        return this;
    }

    public RoverBuilder AjouterObstacleSurPlanète(Obstacle obstacle)
    {
        _obstacles.Add(obstacle);
        return this;
    }
}