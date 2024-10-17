namespace MarsRover;

public class PlanèteToroïdale : IPlanète
{
    public PlanèteToroïdale(int taille)
    {
        if (taille == 0)
            throw new ArgumentOutOfRangeException();
    }

    public (int X, int Y) Normaliser(int x, int y)
    {
        return (0, 0);
    }
}