using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


/** <summary>A parent for various piece kinds.</summary> */
public class Piece : EmptyPiece
{
    string description = "";
    
    string message = "";

    bool hidden = false;

    HashSet<IPlayer> subscribers = [];

    IList<IExchange> children = [];

    IExchange selection = Piece.Empty;

    public override bool Hidden { get => hidden; set => hidden = value; }

    public override IExchange Selection {
        get => selection;
        set
        {
            if (!children.Contains(value))
            {
                throw new InvalidOperationException("Can't select unrelated pieces.");
            }

            selection = value;
        }
    }

    public override IList<IExchange> Children { get => children; set => children = value; }

    public override string Description { get => description; set => description = value; }

    public override string Message { get => message; set => message = value; }

    public override void Subscribe(IPlayer subscriber)
    {
        subscribers.Add(subscriber);
    }

    public override void Unsubscribe(IPlayer subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public override void Trigger()
    {
        foreach (IPlayer subscriber in subscribers.ToArray())
        {
            subscriber.Process(this);
        }
    }
}