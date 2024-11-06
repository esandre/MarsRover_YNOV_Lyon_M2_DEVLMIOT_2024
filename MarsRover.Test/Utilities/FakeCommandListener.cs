using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

internal class FakeCommandListener : ICommandListener
{
    private Action<string> _callback = _ => { };

    public void SimulerReceptionCommande(string command)
    {
        _callback(command);
    }

    public void Subscribe(Action<string> whatToDoWhenCommandReceived)
    {
        _callback = whatToDoWhenCommandReceived;
    }
}