using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class CommandeTest
{
    [Fact]
    public void CommandeAvancer()
    {
        // ETANT DONNE un Rover
        var builder = new RoverBuilder();
        var roverTesté = builder.Build();
        var roverTémoin = builder.Build();

        // QUAND il reçoit la commande "A"
        roverTesté = roverTesté.Recevoir('A');

        // ALORS il est dans un état semblable à un Rover ayant avancé
        roverTémoin = roverTémoin.Avancer();

        Assert.Equal(roverTémoin.X, roverTesté.X);
        Assert.Equal(roverTémoin.Y, roverTesté.Y);
        Assert.Equal(roverTémoin.Orientation, roverTesté.Orientation);
    }

    [Fact]
    public void CommandeReculer()
    {
        // ETANT DONNE un Rover
        var builder = new RoverBuilder();
        var roverTesté = builder.Build();
        var roverTémoin = builder.Build();

        // QUAND il reçoit la commande "R"
        roverTesté = roverTesté.Recevoir('R');

        // ALORS il est dans un état semblable à un Rover ayant reculé
        roverTémoin = roverTémoin.Reculer();

        Assert.Equal(roverTémoin.X, roverTesté.X);
        Assert.Equal(roverTémoin.Y, roverTesté.Y);
        Assert.Equal(roverTémoin.Orientation, roverTesté.Orientation);
    }

    // Cas autre chose qu'un caractère valide
}