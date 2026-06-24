using System.Text.Json.Serialization;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using WrongInput = CoinFlip.Engine.Exceptions.IOException;
using Decision = CoinFlip.Engine.Decisions.InputOutput;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
	// using defaults here for the editor, it doesn't need the fields.
	readonly Board board = Board.Empty;
	readonly TextWriter output = new StringWriter();
	readonly TextReader input = new StringReader("");
	readonly Decision decision = new();

	public InputOutput(Board board, TextReader input, TextWriter output)
	{
		this.board = board;
		this.output = output;
		this.input = input;
	}

	[JsonConstructor]
	public InputOutput()
	{}

	public string Name { get; set; } = "";

	public void VisitPiece(Piece piece)
	{
		IList<IBranch> visible = [.. board.Selection.Children.Where(exchange => !((Option) exchange).Hidden)];
		while (!ReadWrite(visible));
		decision.Apply(board);
		output.WriteLine(board.Selection.Selection.Message);
	}

	private bool ReadWrite(IList<IBranch> visible)
	{
		int counter = 0;

		foreach (Option exchange in visible)
		{
			counter++;
			output.WriteLine($"{counter}. {exchange.Description}");
		}

		try {
			decision.Make(input.ReadLine(), visible);
		} catch (WrongInput error) {
			output.WriteLine(error.Message);
			return false;
		}

		return true;
	}
}