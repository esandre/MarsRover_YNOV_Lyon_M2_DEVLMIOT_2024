namespace MarsRover.Rover;

public static class RoverInterpreter
{
    private static readonly IEqualityComparer<IRover> Comparer = new RoverStateComparator();

    public static IRover Recevoir(this IRover rover, char command) =>
        command switch
        {
            'A' => rover.Avancer(),
            'R' => rover.Reculer(),
            'D' => rover.TournerADroite(),
            'G' => rover.TournerAGauche(),
            _ => throw new InvalidOperationException()
        };

    public static IRover Recevoir(this IRover rover, string command)
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