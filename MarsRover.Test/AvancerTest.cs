using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class AvancerTest
{
    // TODO : BeforeTest

    public static IEnumerable<object[]> NombreIncr�mentsTest�s()
    {
        yield return [1];
        yield return [2];
        yield return [100];
    }

    [Theory]
    [MemberData(nameof(NombreIncr�mentsTest�s))]
    public void Avancer_Nord_Incr�mente_X_N_Fois(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Nord
        var roverInitial = new RoverBuilder()
            .Orient�(Orientation.Nord)
            .Build();
            
        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e X a augment� de <nombreIt�rations>
        Assert.Equal(nombreIt�rations, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [MemberData(nameof(NombreIncr�mentsTest�s))]
    public void Avancer_Sud_D�cr�mente_X_N_Fois(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Sud
        var roverInitial = new RoverBuilder()
            .Orient�(Orientation.Sud)
            .Build();

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e X a augment� de <nombreIt�rations>
        Assert.Equal(-nombreIt�rations, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [MemberData(nameof(NombreIncr�mentsTest�s))]
    public void Avancer_Est_Incr�mente_Y(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Est
        var roverInitial = new RoverBuilder()
            .Orient�(Orientation.Est)
            .Build();

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e Y augmente de <nombreIt�rations>
        Assert.Equal(nombreIt�rations, roverFinal.Y - roverInitial.Y);
    }

    [Theory]
    [MemberData(nameof(NombreIncr�mentsTest�s))]
    public void Avancer_Ouest_D�cr�mente_Y(int nombreIt�rations)
    {
        // ETANT DONNE un Rover orient� Ouest
        var roverInitial = new RoverBuilder()
            .Orient�(Orientation.Ouest)
            .Build();

        // QUAND il avance <nombreIt�rations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreIt�rations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonn�e Y diminue de <nombreIt�rations>
        Assert.Equal(-nombreIt�rations, roverFinal.Y - roverInitial.Y);
    }

    public static IEnumerable<object[]> Cas_Mouvement_Latitudinal_Ne_Modifie_Pas_X()
    {
        yield return [Orientation.Est];
        yield return [Orientation.Ouest];
    }

    public static IEnumerable<object[]> Cas_Mouvement_Longitudinal_Ne_Modifie_Pas_Y()
    {
        yield return [Orientation.Nord];
        yield return [Orientation.Sud];
    }

    [Theory]
    [MemberData(nameof(Cas_Mouvement_Latitudinal_Ne_Modifie_Pas_X))]
    public void Mouvement_Latitudinal_Ne_Modifie_Pas_X(Orientation origine)
    {
        // ETANT DONNE un Rover orient� <origine>
        var roverInitial = new RoverBuilder()
            .Orient�(origine)
            .Build();

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonn�e X n'a pas boug�
        Assert.Equal(0, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [MemberData(nameof(Cas_Mouvement_Longitudinal_Ne_Modifie_Pas_Y))]
    public void Mouvement_Longitudinal_Ne_Modifie_Pas_Y(Orientation origine)
    {
        // ETANT DONNE un Rover orient� <origine>
        var roverInitial = new RoverBuilder()
            .Orient�(origine)
            .Build();

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonn�e Y n'a pas boug�
        Assert.Equal(0, roverFinal.Y - roverInitial.Y);
    }
}