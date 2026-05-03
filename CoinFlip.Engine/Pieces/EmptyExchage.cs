using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


/** <summary>Null object pattern implementation.</summary> */
public class EmptyExchange : Piece, IExchange
{
    public static EmptyExchange Instance = new(); // don't instantiate, use this field instead

    public override void Subscribe(IPlayer subscriber)
    {}

    public override void Unsubscribe(IPlayer subscriber)
    {}

    public override void Trigger()
    {}

    public string Description { get => ""; set {} }

    public string Message { get => ""; set {} }

    public bool Hidden { get => false; set {} }

    public bool Permanent { get => true; set {} }

    public IExchange Selection { get => Instance; set {} }

    public IList<IExchange> Children { get => Array.Empty<IExchange>(); set {} }

    public override void Accept(IPlayer player) {}
}