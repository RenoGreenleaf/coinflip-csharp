using System.Text.Json.Serialization;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
    readonly Board board = Board.Empty;

    public InputOutput(Board board, TextReader input, TextWriter output)
    {
        this.board = board;
    }

    [JsonConstructor]
    public InputOutput()
    {}

    public string Name { get; set; } = "";

    public void VisitPiece(Piece piece)
    {
        throw new NotImplementedException();
    }

    public void VisitExchange(IExchange piece)
    {
        throw new NotImplementedException();
    }
}