namespace MarsRover.Communication;

public interface ICommandListener
{
    void Subscribe(Action<string> whatToDoWhenCommandReceived);
}