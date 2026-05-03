using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece, IExchange
{
    string description = "";

    string message = "";

    bool hidden = false;

    bool permanent = true;

    public string Description { get => description; set => description = value; }

    public string Message { get => message; set => message = value; }

    public bool Hidden { get => hidden; set => hidden = value; }

    public bool Permanent { get => permanent; set => permanent = value; }

    public IExchange Selection { get => EmptyExchange.Instance; set {} }

    public IList<IExchange> Children { get => Array.Empty<IExchange>(); set {} }

    public override void Accept(IPlayer player)
    {
        player.VisitExchange(this);
    }
}