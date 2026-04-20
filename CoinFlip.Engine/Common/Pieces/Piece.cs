using CoinFlip.Engine.AI.Interfaces;
using CoinFlip.Engine.Common.Interfaces;
using CoinFlip.Engine.Terminal.Interfaces;

namespace CoinFlip.Engine.Common.Pieces;


/** <summary>Can be used to realize null object pattern, or as a parent for various piece kinds.</summary> */
public class Piece : IEvent, INode, IExchange, IRelated
{
    private HashSet<IPlayer> subscribers = [];

    public static readonly Piece Empty = new(); // use for null object pattern.

    public string Description { get => ""; set {} }

    public string Message { get => ""; set {} }

    public IExchange Selection { get => Piece.Empty; set {} }

    public IList<IExchange> Children { get => []; set {} }

    public void Act(int input)
    {
        throw new NotImplementedException();
    }

    public void Persist(Dictionary<string, IRelated> relationships)
    {
        throw new NotImplementedException();
    }

    public void Subscribe(IPlayer subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Trigger()
    {
        foreach (IPlayer subscriber in subscribers)
        {
            subscriber.Process(this);
        }
    }
}