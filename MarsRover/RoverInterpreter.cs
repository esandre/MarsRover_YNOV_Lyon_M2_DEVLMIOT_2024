namespace MarsRover;

public static class RoverInterpreter
{
    public static Rover Recevoir(this Rover rover, char command)
    {
        if (command == 'R') return rover.Reculer();
        return rover.Avancer();
    }

    public static Rover Recevoir(this Rover rover, string command)
    {
        foreach (var @char in command)
            rover = rover.Recevoir(@char);
        return rover;
    }
}