namespace MarsRover.Rover;

public static class RoverInterpreter
{
    private static readonly IEqualityComparer<Rover> Comparer = new RoverStateComparator();

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
        {
            var roverFinal = rover.Recevoir(@char);
            if (Comparer.Equals(rover, roverFinal))
                return rover;

            rover = roverFinal;
        }

        return rover;
    }
}