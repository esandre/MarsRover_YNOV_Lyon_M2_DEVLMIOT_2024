using MarsRover.Communication;

namespace MarsRover.Rover;

public class PuppetRover
{
    private readonly IRover _rover;

    public PuppetRover(IRover rover, ICommandListener commandListener)
    {
        _rover = rover;
    }

    public void StartListening()
    {
        _rover.Avancer();
    }
}