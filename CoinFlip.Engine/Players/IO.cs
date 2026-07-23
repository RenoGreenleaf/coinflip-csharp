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
	bool started = true;

	[JsonConstructor]
	public InputOutput()
	{}

	public string Name { get; set; } = "";
	public Board_ Board { set => board = value; }

	public void VisitPiece(Piece piece)
	{
		if (started)
		{
			started = false;
			Console.Out.WriteLine(board.Intro);
		}

		IList<IBranch> visible = [.. board.Selection.Children.Where(exchange => !((Option) exchange).Hidden)];

		if (visible.Count == 0)
		{
			throw new Exception("There's nothing to do.");
		}

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

		string? providedInput = Console.In.ReadLine();

		if (providedInput is null)
		{
			return true;
		}

		try {
			decision.Make(providedInput, visible);
		} catch (WrongInput error) {
			Console.Out.WriteLine(error.Message);
			return false;
		}

		return true;
	}
}