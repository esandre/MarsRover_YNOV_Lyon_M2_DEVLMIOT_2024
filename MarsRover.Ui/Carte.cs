using System.Text;
using MarsRover.Topologie;

namespace MarsRover.Ui;

public class Carte
{
    private readonly IPlanète _planète;
    private readonly (int X, int Y) _boundaries;

    public Carte(IPlanète planète)
    {
        _planète = planète;
        _boundaries = DiscoverMaxSize(planète);
    }

    private static (int X, int Y) DiscoverMaxSize(IPlanète planète)
    {
        var xMax = 0;
        for (var x = 1; planète.Normaliser(x, 0).X != 0; x++)
            xMax = x;

        var yMax = 0;
        for (var y = 1; planète.Normaliser(0, y).Y != 0; y++)
            yMax = y;

        return (xMax, yMax);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        for (var y = _boundaries.Y; y >= 0; y--)
        {
            for (var x = 0; x <= _boundaries.X; x++)
            {
                var estLibre = _planète.Normaliser(x, y).Libre;
                builder.Append(estLibre ? Symboles.CaseDécouverteLibre : Symboles.CaseDécouverteObstacle);
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }
}