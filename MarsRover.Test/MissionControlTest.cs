using MarsRover.Rover;
using MarsRover.Test.Utilities;
using MarsRover.Topologie;

namespace MarsRover.Test;

public class MissionControlTest
{
    public static IEnumerable<object[]> Cas_Avancer_Equivalent_Avec_MissionControl()
    {
        Orientation[] orientations = [Orientation.Nord, Orientation.Est, Orientation.Sud, Orientation.Ouest];
        int[] positionsIntéressantes = [0, 1, 2];
        char[] actionsPossibles = ['A', 'R', 'G', 'D'];

        foreach (var orientationDépart in orientations)
        foreach (var xDépart in positionsIntéressantes)
        foreach (var yDépart in positionsIntéressantes)
        foreach (var action1 in actionsPossibles)
        foreach (var action2 in actionsPossibles)
        {
            var builder = new RoverBuilder()
                .Orienté(orientationDépart)
                .Positionné(xDépart, yDépart);

            yield return [builder, action1, action2];
        }
    }

    [Theory]
    [MemberData(nameof(Cas_Avancer_Equivalent_Avec_MissionControl))]
    public void Avancer_Equivalent_Avec_MissionControl(
        RoverBuilder preconfiguredCase, char action1, char action2)
    {
        // ETANT DONNE un MissionControl connecté à un Rover
        var roverTesté = preconfiguredCase.Build();
        var roverTémoin = preconfiguredCase.Build();
        var missionControl = new MissionControl.MissionControl(new CommandSenderSpy(), roverTesté);

        // QUAND on donne deux ordres à la suite
        missionControl.Envoyer(action1);
        var roverState = missionControl.Envoyer(action2);

        // ALORS le résultat est le même que sur un Rover appelé directement
        roverTémoin = roverTémoin.Recevoir(action1);
        roverTémoin = roverTémoin.Recevoir(action2);
        Assert.Equal(roverTémoin.Orientation, roverState.Orientation);
        Assert.Equal(roverTémoin.X, roverState.X);
        Assert.Equal(roverTémoin.Y, roverState.Y);
    }

    [Fact]
    public void MissionControl_Envoie_Message()
    {
        // ETANT DONNE un MissionControl ayant un CommandSender
        var commandSender = new CommandSenderSpy();
        var missionControl = new MissionControl.MissionControl(
            commandSender, 
            new RoverBuilder().Build());

        // QUAND le MissionControl doit envoyer une commande
        missionControl.Envoyer('A');

        // ALORS un message est vraiment envoyé au CommandSender
        Assert.Contains('A', commandSender.ReceivedCommands);
    }
}