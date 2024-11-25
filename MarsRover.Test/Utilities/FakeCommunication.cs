using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

internal class FakeCommunication : ICommandListener, ICommandSender
{
    private readonly string _channelName;

    public FakeCommunication(string channelName)
    {
        _channelName = channelName;
    }

    private static readonly Dictionary<string, Func<string, RoverState>> Callbacks = new();

    public void Subscribe(Func<string, RoverState> whatToDoWhenCommandReceived)
    {
        Callbacks[_channelName] = whatToDoWhenCommandReceived;
    }

    public Task<RoverState> SendAsync(string action)
    {
        return Task.FromResult(Callbacks[_channelName](action));
    }
}