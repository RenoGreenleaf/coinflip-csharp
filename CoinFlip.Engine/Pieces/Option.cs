using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece, IBranch
{
    string description = "";

    public string Message = "";

    public bool Hidden = false;

    public bool Permanent = true;

    public IList<IBranch> Children { get => Array.Empty<IBranch>(); }

    public string Description { get => description; set => description = value; }
}