using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece_
{
    public override IExchange Selection { get => Piece_.Empty; set {} }

    public override IList<IExchange> Children { get => Array.Empty<IExchange>(); set {} }
}