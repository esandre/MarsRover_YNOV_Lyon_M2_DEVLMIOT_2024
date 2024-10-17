namespace MarsRover.Test;

public class AvancerTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Nord_Incr�mente_X_N_Fois(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Nord
        var roverInitial = new Rover(Orientation.Nord);

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e X a augment� de <nombreIt�rations>
        Assert.Equal(nombreIt�rations, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Sud_D�cr�mente_X_N_Fois(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Nord
        var roverInitial = new Rover(Orientation.Sud);

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e X a augment� de <nombreIt�rations>
        Assert.Equal(-nombreIt�rations, roverFinal.X - roverInitial.X);
    }

    [Fact]
    public void Avancer_Est_Ne_Modifie_Pas_X()
    {
        // ETANT DONNE un Rover orient� Est
        var roverInitial = new Rover(Orientation.Est);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonn�e X n'a pas boug�
        Assert.Equal(0, roverFinal.X - roverInitial.X);
    }

    [Fact]
    public void Avancer_Ouest_Ne_Modifie_Pas_X()
    {
        // ETANT DONNE un Rover orient� Ouest
        var roverInitial = new Rover(Orientation.Ouest);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonn�e X n'a pas boug�
        Assert.Equal(0, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Est_Incr�mente_Y(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Est
        var roverInitial = new Rover(Orientation.Est);

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e Y augmente de <nombreIt�rations>
        Assert.Equal(nombreIt�rations, roverFinal.Y - roverInitial.Y);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(100)]
    public void Avancer_Ouest_D�cr�mente_Y(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Ouest
        var roverInitial = new Rover(Orientation.Ouest);

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e Y diminue de <nombreIt�rations>
        Assert.Equal(-nombreIt�rations, roverFinal.Y - roverInitial.Y);
    }

    [Fact]
    public void Avancer_Nord_Ne_Modifie_Pas_Y()
    {
        // ETANT DONNE un Rover orient� Nord
        var roverInitial = new Rover(Orientation.Nord);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonn�e Y n'a pas boug�
        Assert.Equal(0, roverFinal.Y - roverInitial.Y);
    }

    [Fact]
    public void Avancer_Sud_Ne_Modifie_Pas_Y()
    {
        // ETANT DONNE un Rover orient� Sud
        var roverInitial = new Rover(Orientation.Sud);

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonn�e Y n'a pas boug�
        Assert.Equal(0, roverFinal.Y - roverInitial.Y);
    }
}