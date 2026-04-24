using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Players;


public class InputOutput : IPlayer
{
    IExchange board;

    public InputOutput(IExchange board, TextReader input, TextWriter output)
    {
        this.board = board;
    }

    public void Process(IEvent @event)
    {}
}