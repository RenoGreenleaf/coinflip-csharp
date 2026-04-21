using CoinFlip.Engine.Common.Interfaces;

namespace CoinFlip.Engine.Common.Pieces;


/** <summary>A parent for various piece kinds.</summary> */
public class Piece : EmptyPiece
{
    string description = "";
    
    string message = "";

    HashSet<IPlayer> subscribers = [];

    public static readonly EmptyPiece Empty = new(); // use for null object pattern.

    public override string Description { get => description; set => description = value; }

    public override string Message { get => message; set => message = value; }

    public override void Subscribe(IPlayer subscriber)
    {
        subscribers.Add(subscriber);
    }

    public override void Unsubscribe(IPlayer subscriber)
    {
        if (subscribers.Contains(subscriber))
        {
            subscribers.Remove(subscriber);
        }
    }

    public override void Trigger()
    {
        foreach (IPlayer subscriber in subscribers)
        {
            subscriber.Process(this);
        }
    }
}