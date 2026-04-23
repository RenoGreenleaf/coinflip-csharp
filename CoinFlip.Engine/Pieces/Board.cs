using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Board : Piece
{
    IExchange selection = Piece.Empty;

    IList<IExchange> conversations = [];

    public override IExchange Selection {
        get => selection;
        set
        {
            if (!conversations.Contains(value))
            {
                throw new InvalidOperationException("Can't select unrelated conversation.");
            }

            selection = value;
        }
    }

    public override IList<IExchange> Children { get => conversations; set => conversations = value; }
}