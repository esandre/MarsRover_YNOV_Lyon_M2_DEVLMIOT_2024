using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class MissionControlTest
{
    [Fact]
    public void Avancer_Equivalent_Avec_MissionControl()
    {
        // ETANT DONNE un MissionControl connecté à un Rover
        var builder = new RoverBuilder();
        var roverTesté = builder.Build();
        var roverTémoin = builder.Build();
        var missionControl = new MissionControl.MissionControl(roverTesté);

        // QUAND on donne l'ordre d'avancer
        var roverState = missionControl.AvancerRover();

        // ALORS le résultat est le même que sur un Rover appelé directement
        roverTémoin = roverTémoin.Avancer();
        Assert.Equal(roverTémoin.Orientation, roverState.Orientation);
        Assert.Equal(roverTémoin.X, roverState.X);
        Assert.Equal(roverTémoin.Y, roverState.Y);
    }
}