namespace MarsRover.Communication;

public interface ICommandSender
{
    Task SendAsync(string action);
}