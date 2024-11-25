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
        const string configuration = "x";

        {
            var fakeCommunicationServerSide = new FakeCommunication(configuration);
            var roverSurMars = commonBuilder.Build();
            var _ = new PuppetRover(roverSurMars, fakeCommunicationServerSide);
        }

        {
            var fakeCommunicationClientSide = new FakeCommunication(configuration);
            var missionControl = new MissionControl.MissionControl(
                fakeCommunicationClientSide,commonBuilder.Build());
            var returnedState = missionControl.Envoyer(commande);

            var roverTémoin = commonBuilder.Build();
            roverTémoin = roverTémoin.Recevoir(commande);

            Assert.Equal(roverTémoin.Orientation, returnedState.Orientation);
            Assert.Equal(roverTémoin.X, returnedState.X);
            Assert.Equal(roverTémoin.Y, returnedState.Y);
        }
    }
}