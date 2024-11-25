using MarsRover.Communication;

namespace MarsRover;

public class SocketCommunication : ICommandSender, ICommandListener
{
    private readonly string _configuration;

    public SocketCommunication(string configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(string action)
    {
        throw new NotImplementedException();
    }

    public void Subscribe(Action<string> whatToDoWhenCommandReceived)
    {
        throw new NotImplementedException();
    }
}