using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

internal class FakeCommunication : ICommandListener, ICommandSender
{
    private readonly string _channelName;

    public FakeCommunication(string channelName)
    {
        _channelName = channelName;
    }

    private static readonly Dictionary<string, Action<string>> Callbacks = new();

    public void Subscribe(Action<string> whatToDoWhenCommandReceived)
    {
        Callbacks[_channelName] = whatToDoWhenCommandReceived;
    }

    public Task SendAsync(string action)
    {
        Callbacks[_channelName](action);
        return Task.CompletedTask;
    }
}