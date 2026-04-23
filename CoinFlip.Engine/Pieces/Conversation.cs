using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


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