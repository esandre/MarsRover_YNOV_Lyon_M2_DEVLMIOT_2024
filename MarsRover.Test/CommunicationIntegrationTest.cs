using MarsRover.Rover;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class CommunicationIntegrationTest
{
    [Fact]
    public void Communicates()
    {
        var commonBuilder = new RoverBuilder();
        const string commande = "A";
        var fakeCommunication = new FakeCommunication();

        {
            var roverSurMars = commonBuilder.Build();
            var _ = new PuppetRover(roverSurMars, fakeCommunication);
        }

        {
            var missionControl = new MissionControl.MissionControl(
                fakeCommunication,commonBuilder.Build());
            var returnedState = missionControl.Envoyer(commande);

            var roverTémoin = commonBuilder.Build();
            roverTémoin = roverTémoin.Recevoir(commande);

            Assert.Equal(roverTémoin.Orientation, returnedState.Orientation);
            Assert.Equal(roverTémoin.X, returnedState.X);
            Assert.Equal(roverTémoin.Y, returnedState.Y);
        }
    }
}