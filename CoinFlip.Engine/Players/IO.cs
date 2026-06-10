using System.Text.Json.Serialization;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
    readonly Board board = Board.Empty;
    readonly TextWriter output = new StringWriter();

    public InputOutput(Board board, TextReader input, TextWriter output)
    {
        this.board = board;
        this.output = output;
    }

    [JsonConstructor]
    public InputOutput()
    {}

    public string Name { get; set; } = "";

    public void VisitPiece(Piece piece)
    {
        int counter = 0;
        
        foreach (Option exchange in board.Selection.Children)
        {
            counter++;
            output.WriteLine($"{counter}. {exchange.Description}");
        }
    }
}