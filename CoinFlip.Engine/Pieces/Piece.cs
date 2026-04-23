using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


/** <summary>A parent for various piece kinds.</summary> */
public class Piece : EmptyPiece
{
    string description = "";
    
    string message = "";

    HashSet<IPlayer> subscribers = [];

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