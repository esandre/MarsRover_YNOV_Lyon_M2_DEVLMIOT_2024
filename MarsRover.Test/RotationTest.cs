using MarsRover.Test.Utilities;
using MarsRover.Topologie;

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
        var rover = new Rover(origine, new PlanèteInfinie());

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
        var rover = new Rover(origine, new PlanèteInfinie());

        // QUAND il tourne à gauche
        rover = rover.TournerAGauche();

        // ALORS il est orienté <destination>
        Assert.Equal(destination, rover.Orientation);
    }

    public static IEnumerable<object[]> Cas_Tourner_Ne_Fait_Pas_Bouger()
    {
        Orientation[] orientations = [Orientation.Est, Orientation.Nord, Orientation.Ouest, Orientation.Sud];
        bool[] aGaucheOuNon = [true, false];

        foreach (var orientation in orientations)
        foreach (var aGauche in aGaucheOuNon)
        {
            yield return [orientation, 0, 0, aGauche];
            yield return [orientation, 1, 1, aGauche];
        }
    }

    [Theory]
    [MemberData(nameof(Cas_Tourner_Ne_Fait_Pas_Bouger))]
    public void Tourner_Ne_Fait_Pas_Bouger(Orientation origine, int xOrigine, int yOrigine, bool aGauche)
    {
        // ETANT DONNE un Rover orienté <origine>
        var roverInitial = new Rover(origine, new PlanèteInfinie(), xOrigine, yOrigine);

        // QUAND il tourne
        var roverFinal = aGauche ? roverInitial.TournerAGauche() : roverInitial.TournerADroite();

        // ALORS sa position ne varie pas
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
    }
}