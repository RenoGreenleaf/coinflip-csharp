using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece
{
    public override IExchange Selection { get => Piece.Empty; set {} }

    public override IList<IExchange> Children { get => Array.Empty<IExchange>(); set {} }
}