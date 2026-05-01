using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Board : Piece, IExchange
{
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public bool Hidden { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public bool Permanent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public IPiece Selection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public IList<IPiece> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void Accept(IPlayer player)
    {
        player.VisitExchange(this);
    }
}