namespace MarsRover.Test;

public class AvancerTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Nord_Incrémente_X_N_Fois(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Nord
        var roverInitial = new Rover(Orientation.Nord);

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée X a augmenté de <nombreItérations>
        Assert.Equal(nombreItérations, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Sud_Décrémente_X_N_Fois(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Nord
        var roverInitial = new Rover(Orientation.Sud);

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée X a augmenté de <nombreItérations>
        Assert.Equal(-nombreItérations, roverFinal.X - roverInitial.X);
    }

    [Fact]
    public void Avancer_Est_Ne_Modifie_Pas_X()
    {
        // ETANT DONNE un Rover orienté Est
        var roverInitial = new Rover(Orientation.Est);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonnée X n'a pas bougé
        Assert.Equal(0, roverFinal.X - roverInitial.X);
    }

    [Fact]
    public void Avancer_Ouest_Ne_Modifie_Pas_X()
    {
        // ETANT DONNE un Rover orienté Ouest
        var roverInitial = new Rover(Orientation.Ouest);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonnée X n'a pas bougé
        Assert.Equal(0, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Est_Incrémente_Y(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Est
        var roverInitial = new Rover(Orientation.Est);

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée Y augmente de <nombreItérations>
        Assert.Equal(nombreItérations, roverFinal.Y - roverInitial.Y);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Ouest_Décrémente_Y(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Ouest
        var roverInitial = new Rover(Orientation.Ouest);

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée Y diminue de <nombreItérations>
        Assert.Equal(-nombreItérations, roverFinal.Y - roverInitial.Y);
    }

    [Fact]
    public void Avancer_Nord_Ne_Modifie_Pas_Y()
    {
        // ETANT DONNE un Rover orienté Nord
        var roverInitial = new Rover(Orientation.Nord);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonnée Y n'a pas bougé
        Assert.Equal(0, roverFinal.Y - roverInitial.Y);
    }

    [Fact]
    public void Avancer_Sud_Ne_Modifie_Pas_Y()
    {
        // ETANT DONNE un Rover orienté Sud
        var roverInitial = new Rover(Orientation.Sud);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonnée Y n'a pas bougé
        Assert.Equal(0, roverFinal.Y - roverInitial.Y);
    }
}