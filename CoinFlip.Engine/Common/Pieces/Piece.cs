using CoinFlip.Engine.AI.Interfaces;
using CoinFlip.Engine.Common.Interfaces;
using CoinFlip.Engine.Terminal.Interfaces;

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

    public override void Trigger()
    {
        foreach (IPlayer subscriber in subscribers)
        {
            subscriber.Process(this);
        }
    }
}