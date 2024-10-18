using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class SuiteCommandesTest
{
    [Theory]
    [InlineData("AA")]
    [InlineData("AR")]
    public void Avancer2Fois(string commande)
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
}