using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using WrongInput = CoinFlip.Engine.Exceptions.IOException;

namespace CoinFlip.Engine.Decisions;


public class InputOutput : IDecision
{
	Option? selection;

	public void Apply(Board board)
	{
		if (selection is null)
		{
			throw new InvalidOperationException("Trying to select an option without players input.");
		}

		board.Selection.Selection = selection;
	}

	public void Make(TextReader input, IList<IBranch> options)
	{
		int index;
	
		string? providedInput = input.ReadLine();

		if (providedInput is null)
		{
			return;
		}

		try {
			index = int.Parse(providedInput);
		} catch (FormatException) {
			throw new WrongInput("The choice should be a number.");
		}

		if (index > options.Count || index < 1)
		{
			throw new WrongInput($"Item {index} is not in the list.");
		}

		selection = (Option) options[index - 1];
	}
}