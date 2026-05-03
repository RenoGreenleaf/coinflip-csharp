using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Board : Piece, IExchange
{
    string description = "";

    string message = "";

    bool hidden = false;

    bool permanent = true;

    IExchange selection = EmptyExchange.Instance;

    IList<IExchange> children = [];

    /** <summary>Summary</summary> */
    public string Description { get => description; set => description = value; }

    /** <summary>Intro</summary> */
    public string Message { get => message; set => message = value; }
    
    public bool Hidden { get => hidden; set => hidden = value; }
    
    public bool Permanent { get => permanent; set => permanent = value; }
    
    public IExchange Selection
    {
        get => selection;
        set
        {
            if (!children.Contains(value))
            {
                throw new InvalidOperationException();
            }

            selection = value;
        }
    }
    
    public IList<IExchange> Children { get => children; set => children = value; }

    public override void Accept(IPlayer player)
    {
        player.VisitExchange(this);
    }
}