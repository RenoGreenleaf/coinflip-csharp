using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Conversation : Piece, IExchange
{
    readonly IExchange helper = new Board();

    public string Description { get => helper.Description; set => helper.Description = value; }
    
    public string Message { get => helper.Message; set => helper.Message = value; }
    
    public bool Hidden { get => helper.Hidden; set => helper.Hidden = value; }
    
    public bool Permanent { get => helper.Permanent; set => helper.Permanent = value; }
    
    public IExchange Selection { get => helper.Selection; set => helper.Selection = value; }
    
    public IList<IExchange> Children { get => helper.Children; set => helper.Children = value; }

    public override void Accept(IPlayer player)
    {
        player.VisitExchange(this);
    }
}