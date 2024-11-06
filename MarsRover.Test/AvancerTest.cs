using MarsRover.Test.Utilities;
using MarsRover.Topologie;

namespace MarsRover.Test;

public class AvancerTest
{
    public static IEnumerable<object[]> NombreIncrémentsTestés()
    {
        yield return [1];
        yield return [2];
        yield return [100];
    }

    [Theory]
    [MemberData(nameof(NombreIncrémentsTestés))]
    public void Avancer_Nord_Incrémente_X_N_Fois(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Nord
        var roverInitial = new RoverBuilder()
            .Orienté(Orientation.Nord)
            .Build();
            
        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée X a augmenté de <nombreItérations>
        Assert.Equal(nombreItérations, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [MemberData(nameof(NombreIncrémentsTestés))]
    public void Avancer_Sud_Décrémente_X_N_Fois(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Sud
        var roverInitial = new RoverBuilder()
            .Orienté(Orientation.Sud)
            .Build();

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée X a augmenté de <nombreItérations>
        Assert.Equal(-nombreItérations, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [MemberData(nameof(NombreIncrémentsTestés))]
    public void Avancer_Est_Incrémente_Y(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Est
        var roverInitial = new RoverBuilder()
            .Orienté(Orientation.Est)
            .Build();

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée Y augmente de <nombreItérations>
        Assert.Equal(nombreItérations, roverFinal.Y - roverInitial.Y);
    }

    [Theory]
    [MemberData(nameof(NombreIncrémentsTestés))]
    public void Avancer_Ouest_Décrémente_Y(int nombreItérations)
    {
        // ETANT DONNE un Rover orienté Ouest
        var roverInitial = new RoverBuilder()
            .Orienté(Orientation.Ouest)
            .Build();

        // QUAND il avance <nombreItérations> fois
        var roverFinal = roverInitial;
        for (var i = 0; i < nombreItérations; i++)
            roverFinal = roverFinal.Avancer();

        // ALORS sa coordonnée Y diminue de <nombreItérations>
        Assert.Equal(-nombreItérations, roverFinal.Y - roverInitial.Y);
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
        // ETANT DONNE un Rover orienté <origine>
        var roverInitial = new RoverBuilder()
            .Orienté(origine)
            .Build();

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonnée X n'a pas bougé
        Assert.Equal(0, roverFinal.X - roverInitial.X);
    }

    [Theory]
    [MemberData(nameof(Cas_Mouvement_Longitudinal_Ne_Modifie_Pas_Y))]
    public void Mouvement_Longitudinal_Ne_Modifie_Pas_Y(Orientation origine)
    {
        // ETANT DONNE un Rover orienté <origine>
        var roverInitial = new RoverBuilder()
            .Orienté(origine)
            .Build();

        // QUAND il avance
        var roverFinal = roverInitial.Avancer();

        // ALORS sa coordonnée Y n'a pas bougé
        Assert.Equal(0, roverFinal.Y - roverInitial.Y);
    }
}