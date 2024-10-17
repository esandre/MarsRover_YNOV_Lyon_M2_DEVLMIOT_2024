namespace MarsRover.Test;

public class GéométrieToroïdaleTest
{
    [Fact]
    public void Taille_Zero_Impossible()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new PlanèteToroïdale(0));
    }
}