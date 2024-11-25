namespace MarsRover.Communication;

public interface ICommandSender
{
    Task<RoverState> SendAsync(string action);
}