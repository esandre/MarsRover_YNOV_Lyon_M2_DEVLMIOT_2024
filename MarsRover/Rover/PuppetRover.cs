﻿using MarsRover.Communication;

namespace MarsRover.Rover;

public class PuppetRover
{
    public PuppetRover(IRover rover, ICommandListener commandListener)
    {
        commandListener.Subscribe(command => rover.Recevoir(command));
    }
}