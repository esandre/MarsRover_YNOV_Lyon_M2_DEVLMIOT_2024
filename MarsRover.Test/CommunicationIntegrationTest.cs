using MarsRover.Communication;
using MarsRover.Rover;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class CommunicationIntegrationTest
{
    public static IEnumerable<object[]> Cas_Communicates()
    {
        yield return [typeof(FakeCommunication), nameof(FakeCommunication)];
    }

    [Theory]
    [MemberData(nameof(Cas_Communicates))]
    public void Communicates(Type communicationStackType, string commonConfiguration)
    {
        var commonBuilder = new RoverBuilder();
        const string commande = "A";

        CommandListenerSpy serverSideSpy;

        {
            var fakeCommunicationServerSide = (ICommandListener) Activator.CreateInstance(
                communicationStackType, 
                commonConfiguration)!;

            serverSideSpy = new CommandListenerSpy(fakeCommunicationServerSide);
                
            var roverSurMars = commonBuilder.Build();
            var _ = new PuppetRover(roverSurMars, serverSideSpy);
        }

        {
            var fakeCommunicationClientSide = (ICommandSender)Activator.CreateInstance(
                communicationStackType,
                commonConfiguration)!;

            var missionControl = new MissionControl.MissionControl(
                fakeCommunicationClientSide,commonBuilder.Build());

            var returnedState = missionControl.Envoyer(commande);

            var roverTémoin = commonBuilder.Build();
            roverTémoin = roverTémoin.Recevoir(commande);

            Assert.Equal(roverTémoin.Orientation, returnedState.Orientation);
            Assert.Equal(roverTémoin.X, returnedState.X);
            Assert.Equal(roverTémoin.Y, returnedState.Y);

            Assert.Equal(returnedState, serverSideSpy.LastReturnedState);
        }
    }
}