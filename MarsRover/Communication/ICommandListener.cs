namespace MarsRover.Communication;

public interface ICommandListener
{
    void Subscribe(Func<string, RoverState> whatToDoWhenCommandReceived);
}