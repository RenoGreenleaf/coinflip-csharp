using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Decisions;


public class InputOutput : IDecision
{
    public void Apply(IPiece board)
    {}

    public void Make(string input, IList<IBranch> options)
    {
        try {
            int offset = int.Parse(input);
        } catch (FormatException) {
            throw new IOException("The choice should be a number.");
        }
    }
}