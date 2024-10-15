namespace MarsRover.Test;

public class RotationTest
{
    [Fact]
    public void Tourner_A_Droite_Depuis_Le_Nord_Amène_A_L_Est()
    {
        // ETANT DONNE un Rover orienté Nord
        var rover = new Rover(Orientation.Nord);

        // QUAND il tourne à droite
        rover = rover.TournerADroite();

        // ALORS il est orienté Est
        Assert.Equal(Orientation.Est, rover.Orientation);
    }
}