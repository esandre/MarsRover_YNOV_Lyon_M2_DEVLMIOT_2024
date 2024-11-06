using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

internal class FakeCommunication : ICommandListener, ICommandSender
{
    private Action<string> _callback = _ => { };

    public void Subscribe(Action<string> whatToDoWhenCommandReceived)
    {
        _callback = whatToDoWhenCommandReceived;
    }

    public Task SendAsync(string action)
    {
        _callback(action);
        return Task.CompletedTask;
    }
}