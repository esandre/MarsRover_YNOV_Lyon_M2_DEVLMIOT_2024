namespace MarsRover;

public class PlanèteToroïdale : IPlanète
{
    private readonly int _taille;

    public PlanèteToroïdale(int taille)
    {
        if (taille == 0)
            throw new ArgumentOutOfRangeException();

        _taille = taille;
    }

    public (int X, int Y, bool Libre) Normaliser(int x, int y)
    {
        return (AbsoluteModulo(x, _taille), AbsoluteModulo(y, _taille), true);
    }

    public bool EstLibre(int x, int y) => true;

    private static int AbsoluteModulo(int x, int mod)
    {
        return ((x + mod) % mod) % -mod;
    }
}