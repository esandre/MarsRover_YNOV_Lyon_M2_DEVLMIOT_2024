using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class ReculerTest
{
    public static IEnumerable<object[]> Cas_Reculer_Equivaut_A_Avancer_Depuis_Opposé()
    {
        yield return [Orientation.Nord, Orientation.Sud];
        yield return [Orientation.Sud, Orientation.Nord];
        yield return [Orientation.Est, Orientation.Ouest];
        yield return [Orientation.Ouest, Orientation.Est];
    }

    [Theory]
    [MemberData(nameof(Cas_Reculer_Equivaut_A_Avancer_Depuis_Opposé))]
    public void Reculer_Equivaut_A_Avancer_Depuis_Opposé(Orientation origine, Orientation opposée)
    {
        // ETANT DONNE un Rover orienté <origine>
        var roverTesté = new Rover(origine, new PlanèteInfinie());

        // QUAND il recule
        roverTesté = roverTesté.Reculer();

        // ALORS il est à la même position qu'un Rover orienté <opposé> avançant
        var roverTémoin = new Rover(opposée, new PlanèteInfinie()).Avancer();
        Assert.Equal(roverTémoin.X, roverTesté.X);
        Assert.Equal(roverTémoin.Y, roverTesté.Y);
    }
}