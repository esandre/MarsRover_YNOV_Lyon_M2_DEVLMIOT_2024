using MarsRover.Rover;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class PuppetRoverTest
{
    [Fact]
    public void Commande_Recue_Equivalente()
    {
        // ETANT DONNE un PuppetRover
        var rover = new RoverSpy();
        var fakeCommandListener = new FakeCommandListener();
        var puppetRover = new PuppetRover(rover, fakeCommandListener);

        // QUAND il reçoit une commande
        fakeCommandListener.SimulerReceptionCommande('A');
        puppetRover.StartListening();

        // ALORS cette commande est transmise au Rover sous-jacent
        Assert.Equal('A', rover.LastReceivedCommand);
    }
}