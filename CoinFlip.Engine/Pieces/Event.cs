namespace CoinFlip.Engine.Interfaces;


public abstract class Event : IPiece
{
    HashSet<IPlayer> subscribers = [];

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
        player.VisitEvent(this);
    }
}