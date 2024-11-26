using MarsRover.Rover;
using MarsRover.Topologie;

namespace MarsRover.Ui;

public class AffichageRover
{
    private readonly Carte _carte;
    private readonly RoverState _roverState;

    internal AffichageRover(Carte carte, RoverState roverState)
    {
        _carte = carte;
        _roverState = roverState;
    }

    public override string ToString()
    {
        var lignes = _carte.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var noLigne = lignes.Length - 1 - _roverState.X;
        var noColonne = _roverState.Y * 2;

        lignes[noLigne] = lignes[noLigne]
            .Remove(noColonne, 2)
            .Insert(noColonne, SymboleRover());

        return string.Join(Environment.NewLine, lignes) + Environment.NewLine;
    }

    private string SymboleRover()
    {
        if (_roverState.Orientation == Orientation.Nord) 
            return Symboles.CaseRoverNord;
        if (_roverState.Orientation == Orientation.Est) 
            return Symboles.CaseRoverEst;
        if (_roverState.Orientation == Orientation.Sud) 
            return Symboles.CaseRoverSud;
        if (_roverState.Orientation == Orientation.Ouest) 
            return Symboles.CaseRoverOuest;
        throw new InvalidOperationException();
    }
}

public static class AffichageRoverExtensions
{
    public static AffichageRover Représenter(this Carte carte, IRover rover)
    {
        return new AffichageRover(carte, RoverState.FromRover(rover));
    }
}