using System.Collections.Concurrent;
using MarsRover.Communication;

namespace MarsRover.Test.Utilities;

internal class CommandListenerSpy : ICommandListener
{
    private readonly ICommandListener _behavior;
    private readonly ConcurrentStack<(string, RoverState)> _invocations;

    public RoverState? LastReturnedState => _invocations.LastOrDefault().Item2;

    public CommandListenerSpy(ICommandListener behavior)
    {
        _behavior = behavior;
        _invocations = new ConcurrentStack<(string, RoverState)>();
    }

    public void Subscribe(Func<string, RoverState> whatToDoWhenCommandReceived)
    {
        _behavior.Subscribe(
            command => SpyCallback(command, whatToDoWhenCommandReceived)
        );
    }

    private RoverState SpyCallback(string command, Func<string, RoverState> originalCallback)
    {
        var result = originalCallback(command);
        _invocations.Push((command, result));
        return result;
    }
}