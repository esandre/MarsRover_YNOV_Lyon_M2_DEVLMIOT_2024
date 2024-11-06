using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

public class CommandSenderSpy : ICommandSender
{
    public IEnumerable<char> ReceivedCommands => _receivedCommands;

    private readonly List<char> _receivedCommands = [];

    public Task SendAsync(char action)
    {
        _receivedCommands.Add(action);
        return Task.CompletedTask;
    }
}