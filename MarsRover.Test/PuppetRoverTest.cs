using MarsRover.Rover;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class PuppetRoverTest
{
    [Theory]
    [InlineData("A")]
    [InlineData("RG")]
    public void Commande_Recue_Equivalente(string command)
    {
        // ETANT DONNE un PuppetRover abonné à listener
        var rover = new RoverSpy(new RoverBuilder().Build());
        var fakeCommandListener = new FakeCommunication(nameof(Commande_Recue_Equivalente));
        var _ = new PuppetRover(rover, fakeCommandListener);

        // QUAND le listener reçoit une commande
        fakeCommandListener.SendAsync(command);

        // ALORS cette commande est transmise au Rover sous-jacent
        Assert.Equal(command, rover.AllReceivedCommands);
    }
}