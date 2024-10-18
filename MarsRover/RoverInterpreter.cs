namespace MarsRover;

public static class RoverInterpreter
{
    public static Rover Recevoir(this Rover rover, char command) =>
        command switch
        {
            'A' => rover.Avancer(),
            'R' => rover.Reculer(),
            'D' => rover.TournerADroite(),
            'G' => rover.TournerAGauche(),
            _ => throw new InvalidOperationException()
        };

    public static Rover Recevoir(this Rover rover, string command)
    {
        foreach (var @char in command)
            rover = rover.Recevoir(@char);
        return rover;
    }
}