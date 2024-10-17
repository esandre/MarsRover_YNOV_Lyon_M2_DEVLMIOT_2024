namespace MarsRover.Test;

public class GéométrieToroïdaleTest
{
    [Fact]
    public void Taille_Zero_Impossible()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new PlanèteToroïdale(0));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Taille_Un_Mouvement_Impossible(bool avancer)
    {
        // ETANT DONNE un Rover sur une planète toroïdale de taille 1
        var planète = new PlanèteToroïdale(1);
        var roverInitial = new Rover(Orientation.Nord, planète: planète);

        // QUAND il avance ou recule
        var roverFinal = avancer ? roverInitial.Avancer() : roverInitial.Reculer();

        // ALORS sa position reste la même
        Assert.Equal(roverInitial.X, roverFinal.X);
        Assert.Equal(roverInitial.Y, roverFinal.Y);
    }
}