using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
    IExchange board;

    public InputOutput(IExchange board, TextReader input, TextWriter output)
    {
        this.board = board;
    }

    public void VisitPiece(Piece piece)
    {
        throw new NotImplementedException();
    }

    public void VisitExchange(IExchange piece)
    {
        throw new NotImplementedException();
    }
}