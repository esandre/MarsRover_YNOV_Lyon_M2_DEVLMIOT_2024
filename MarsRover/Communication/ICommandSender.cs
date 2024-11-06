namespace MarsRover.Communication;

public interface ICommandSender
{
    Task SendAsync(char action);
}