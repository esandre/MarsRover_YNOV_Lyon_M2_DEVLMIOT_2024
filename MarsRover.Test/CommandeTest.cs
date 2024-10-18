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

    public static IEnumerable<object[]> Cas_SuiteCommandes()
    {
        char[] commandesBase = ['A', 'R', 'D', 'G'];

        foreach (var commande1 in commandesBase)
        foreach (var commande2 in commandesBase)
            yield return [$"{commande1}{commande2}"];
    }

    [Theory]
    [MemberData(nameof(Cas_SuiteCommandes))]
    public void SuiteCommandes(string commande)
    {
        // ETANT DONNE un Rover
        var builder = new RoverBuilder();
        var roverTesté = builder.Build();
        var roverTémoin = builder.Build();

        // QUAND on lui transmet la commande <commande>
        roverTesté = roverTesté.Recevoir(commande);

        // ALORS il est dans le même état qu'un Rover qui aurait reçu chacun des caractères séparément
        foreach (var caractère in commande)
            roverTémoin = roverTémoin.Recevoir(caractère);

        // TODO : Duplication
        Assert.Equal(roverTémoin.X, roverTesté.X);
        Assert.Equal(roverTémoin.Y, roverTesté.Y);
        Assert.Equal(roverTémoin.Orientation, roverTesté.Orientation);
    }

    [Fact]
    public void SuiteCommandesAvecObstacle()
    {
        // ETANT DONNE un Obstacle en 1,0
        var obstacle = new Obstacle(1, 0);

        // ET un Rover orienté Nord en 0,0
        var roverInitial = new RoverBuilder()
            .AjouterObstacleSurPlanète(obstacle)
            .Orienté(Orientation.Nord)
            .Positionné(0, 0)
            .Build();

        // QUAND le Rover reçoit la commande "AR"
        var roverFinal = roverInitial.Recevoir("AR");

        // ALORS il n'a pas bougé
        // Explication : A n'est pas possible (obstacle), R ne doit pas être exécuté. Le Rover ne bouge donc pas.
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
        Assert.Equal(roverInitial.Orientation, roverFinal.Orientation);
    }
}