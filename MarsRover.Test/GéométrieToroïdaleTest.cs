using MarsRover.Topologie;

namespace MarsRover.Test;

public class GéométrieToroïdaleTest
{
    [Fact]
    public void Taille_Zero_Impossible()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new PlanèteToroïdale(0));
    }

    public static IEnumerable<object[]> Cas_Taille_Un_Mouvement_Impossible()
    {
        Orientation[] orientations = [Orientation.Est, Orientation.Nord, Orientation.Ouest, Orientation.Sud];
        bool[] avancerOuNon = [true, false];
        int[] tailles = [1, 2, 10];

        foreach (var orientation in orientations)
        foreach (var avancer in avancerOuNon)
        foreach (var taille in tailles)
        {
            yield return [orientation, taille, 0, 0, avancer];
            yield return [orientation, taille, 1, 1, avancer];
        }
    }

    [Theory]
    [MemberData(nameof(Cas_Taille_Un_Mouvement_Impossible))]
    public void Retour_Au_Départ(Orientation origine, int taille, int xOrigine, int yOrigine, bool avancer)
    {
        // ETANT DONNE une planète toroïdale de taille <taille>
        var planète = new PlanèteToroïdale(taille);

        // ET un Rover orienté <origine> positionné <xOrigine>, <yOrigine> sur cette planète
        var roverInitial = new Rover.Rover(origine, planète, xOrigine, yOrigine);

        // QUAND il avance ou recule <taille> fois
        var roverFinal = roverInitial;
        for(var mouvements = 0; mouvements < taille; mouvements ++)
            roverFinal = avancer ? roverFinal.Avancer() : roverFinal.Reculer();

        // ALORS sa position revient au départ
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
    }

    public static IEnumerable<object[]> Cas_Mouvement_Possible()
    {
        Orientation[] orientations = [Orientation.Est, Orientation.Nord, Orientation.Ouest, Orientation.Sud];
        bool[] avancerOuNon = [true, false];
        int[] tailles = [2, 10];

        foreach (var orientation in orientations)
        foreach (var avancer in avancerOuNon)
        foreach (var taille in tailles)
        {
            yield return [orientation, taille, 0, 0, avancer];
            yield return [orientation, taille, 1, 1, avancer];
        }
    }

    [Theory]
    [MemberData(nameof(Cas_Mouvement_Possible))]
    public void Mouvement_Possible(Orientation origine, int taille, int xOrigine, int yOrigine, bool avancer)
    {
        // ETANT DONNE une planète toroïdale de taille <taille>
        var planète = new PlanèteToroïdale(taille);

        // ET un Rover orienté <origine> positionné <xOrigine>, <yOrigine> sur cette planète
        var roverInitial = new Rover.Rover(origine, planète, xOrigine, yOrigine);

        // QUAND il avance ou recule <taille - 1> fois
        var roverFinal = roverInitial;
        for(var mouvements = 1; mouvements < taille; mouvements ++)
            roverFinal = avancer ? roverFinal.Avancer() : roverFinal.Reculer();

        // ALORS sa position ne revient pas au départ
        Assert.NotEqual((roverInitial.X, roverInitial.Y), (roverFinal.X, roverFinal.Y));
    }
}