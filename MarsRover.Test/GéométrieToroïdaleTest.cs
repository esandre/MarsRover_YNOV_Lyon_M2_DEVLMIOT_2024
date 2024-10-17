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

        foreach (var orientation in orientations)
        foreach (var avancer in avancerOuNon)
        {
            yield return [orientation, 0, 0, avancer];
            yield return [orientation, 1, 1, avancer];
        }
    }

    [Theory]
    [MemberData(nameof(Cas_Taille_Un_Mouvement_Impossible))]
    public void Taille_Un_Mouvement_Impossible(Orientation origine, int xOrigine, int yOrigine, bool avancer)
    {
        // ETANT DONNE une planète toroïdale de taille 1
        var planète = new PlanèteToroïdale(1);

        // ET un Rover orienté <origine> positionné <xOrigine>, <yOrigine> sur cette planète
        var roverInitial = new Rover(origine, planète, xOrigine, yOrigine);

        // QUAND il avance ou recule
        var roverFinal = avancer ? roverInitial.Avancer() : roverInitial.Reculer();

        // ALORS sa position reste la même
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
    }
}