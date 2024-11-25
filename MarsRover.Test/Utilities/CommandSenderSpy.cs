using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

public class CommandSenderSpy : ICommandSender
{
    public IEnumerable<string> ReceivedCommands => _receivedCommands;

    private readonly List<string> _receivedCommands = [];

    public Task<RoverState> SendAsync(string action)
    {
        _receivedCommands.Add(action);
        return Task.FromResult(new RoverState());
    }
}