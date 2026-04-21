using CoinFlip.Engine.AI.Interfaces;
using CoinFlip.Engine.Common.Interfaces;
using CoinFlip.Engine.Terminal.Interfaces;

namespace CoinFlip.Engine.Common.Pieces;


/** <summary>Null object pattern implementation.</summary> */
public class EmptyPiece : IEvent, INode, IExchange, IRelated
{
    // no need to instantiate the class, using this field is more performant.
    public static readonly EmptyPiece Empty = new();

    public virtual string Description { get => ""; set {} }

    public virtual string Message { get => ""; set {} }

    public virtual IExchange Selection { get => Empty; set {} }

    public virtual IList<IExchange> Children { get => []; set {} }

    public virtual void Act(int input)
    {}

    public virtual void Persist(IDictionary<string, IRelated> relationships)
    {}

    public virtual void Subscribe(IPlayer subscriber)
    {}

    public virtual void Unsubscribe(IPlayer subscriber)
    {}

    public virtual void Trigger()
    {}
}