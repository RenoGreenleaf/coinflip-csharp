using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Players;


public class IO : IPlayer
{
    IExchange board;

    public IO(IExchange board)
    {
        this.board = board;
    }

    public void Process(IEvent @event)
    {}
}