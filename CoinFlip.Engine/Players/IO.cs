using System.Text.Json.Serialization;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using WrongInput = CoinFlip.Engine.Exceptions.IOException;
using Decision = CoinFlip.Engine.Decisions.InputOutput;
using Board_ = CoinFlip.Engine.Pieces.Board;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
	// using defaults here for the editor, it doesn't need the fields.
	readonly Decision decision = new();
	Board_ board = Board_.Empty;

	[JsonConstructor]
	public InputOutput()
	{}

	public string Name { get; set; } = "";
	public Board_ Board { set => board = value; }

	public void VisitPiece(Piece piece)
	{
		IList<IBranch> visible = [.. board.Selection.Children.Where(exchange => !((Option) exchange).Hidden)];
		while (!ReadWrite(visible));
		decision.Apply(board);
		Console.Out.WriteLine(board.Selection.Selection.Message);
	}

	private bool ReadWrite(IList<IBranch> visible)
	{
		int counter = 0;

		foreach (Option exchange in visible)
		{
			counter++;
			Console.Out.WriteLine($"{counter}. {exchange.Description}");
		}

		try {
			decision.Make(Console.In.ReadLine(), visible);
		} catch (WrongInput error) {
			Console.Out.WriteLine(error.Message);
			return false;
		}

		return true;
	}
}