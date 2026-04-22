using CoinFlip.Engine.Common.Pieces;
using CoinFlip.Engine.Terminal.Interfaces;

namespace CoinFlip.Engine.Terminal.Pieces;


public class Conversation : Piece
{
    IExchange selection = Piece.Empty;

    IList<IExchange> options = [];

    public override IExchange Selection {
        get => selection;
        set
        {
            if (!options.Contains(value))
            {
                throw new InvalidOperationException("Can't select unrelated conversation.");
            }

            selection = value;
        }
    }

    public override IList<IExchange> Children { get => options; set => options = value; }
}