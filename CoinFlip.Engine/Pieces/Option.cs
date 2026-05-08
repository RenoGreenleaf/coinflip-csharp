using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece, IBranch
{
    public string Description { get; set; } = "";

    public string Message { get; set; } = "";

    public bool Hidden { get; set; } = false;

    public bool Permanent { get; set; } = true;

    public IList<IBranch> Children { get => Array.Empty<IBranch>(); }
}