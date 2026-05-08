using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
    readonly Board board;

    public InputOutput(Board board, TextReader input, TextWriter output)
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