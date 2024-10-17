namespace MarsRover.Test;

public class RotationTest
{
    public static IEnumerable<object[]> Cas_Tourner_A_Droite()
    {
        yield return [Orientation.Nord, Orientation.Est];
        yield return [Orientation.Est, Orientation.Sud];
        yield return [Orientation.Sud, Orientation.Ouest];
        yield return [Orientation.Ouest, Orientation.Nord];
    }

    public static IEnumerable<object[]> Cas_Tourner_A_Gauche()
    {
        return Cas_Tourner_A_Droite().Select(cas => cas.Reverse().ToArray());
    }

    [Theory]
    [MemberData(nameof(Cas_Tourner_A_Droite))]
    public void Tourner_A_Droite(Orientation origine, Orientation destination)
    {
        // ETANT DONNE un Rover orienté <origine>
        var rover = new Rover(origine);

        // QUAND il tourne à droite
        rover = rover.TournerADroite();

        // ALORS il est orienté <destination>
        Assert.Equal(destination, rover.Orientation);
    }

    [Theory]
    [MemberData(nameof(Cas_Tourner_A_Gauche))]
    public void Tourner_A_Gauche(Orientation origine, Orientation destination)
    {
        // ETANT DONNE un Rover orienté <origine>
        var rover = new Rover(origine);

        // QUAND il tourne à gauche
        rover = rover.TournerAGauche();

        // ALORS il est orienté <destination>
        Assert.Equal(destination, rover.Orientation);
    }
}