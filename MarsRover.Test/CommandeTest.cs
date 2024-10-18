using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class CommandeTest
{
    public static IEnumerable<object[]> Cas_CommandeEquivalenteAAction()
    {
        yield return ['A', (Func<Rover, Rover>) (rover => rover.Avancer())];
        yield return ['R', (Func<Rover, Rover>) (rover => rover.Reculer())];
        yield return ['D', (Func<Rover, Rover>) (rover => rover.TournerADroite())];
        yield return ['G', (Func<Rover, Rover>) (rover => rover.TournerAGauche())];
    }

    [Theory]
    [MemberData(nameof(Cas_CommandeEquivalenteAAction))]
    public void CommandeEquivalenteAAction(char commande, Func<Rover, Rover> action)
    {
        // ETANT DONNE un Rover
        var builder = new RoverBuilder();
        var roverTesté = builder.Build();
        var roverTémoin = builder.Build();

        // QUAND il reçoit la commande <commande>
        roverTesté = roverTesté.Recevoir(commande);

        // ALORS il est dans un état semblable à un Rover ayant effectué <action>
        roverTémoin = action(roverTémoin);

        Assert.Equal(roverTémoin.X, roverTesté.X);
        Assert.Equal(roverTémoin.Y, roverTesté.Y);
        Assert.Equal(roverTémoin.Orientation, roverTesté.Orientation);
    }

    [Theory]
    [InlineData(' ')]
    [InlineData('X')]
    [InlineData('1')]
    public void Caractère_Interdit_Throws(char commande)
    {
        // ETANT DONNE un Rover
        var rover = new RoverBuilder().Build();

        // QUAND il reçoit la commande invalide <commande>
        void Act() => rover.Recevoir(commande);

        // ALORS une exception est lancée
        Assert.Throws<InvalidOperationException>(Act);
    }
}