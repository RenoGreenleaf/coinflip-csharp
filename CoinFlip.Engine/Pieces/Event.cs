using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;

// TODO: rename Event to Piece
public class Event : IPiece
{
    readonly HashSet<IPlayer> subscribers = [];

    public virtual void Subscribe(IPlayer subscriber)
    {
        subscribers.Add(subscriber);
    }

    public virtual void Unsubscribe(IPlayer subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public virtual void Trigger()
    {
        foreach (IPlayer subscriber in subscribers.ToArray())
        {
            Accept(subscriber);
        }
    }

    public virtual void Accept(IPlayer player)
    {
        player.VisitPiece(this);
    }
}