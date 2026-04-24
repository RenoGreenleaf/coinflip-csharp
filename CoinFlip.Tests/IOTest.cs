using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;

namespace CoinFlip.Tests;


public class IOTest
{
    [Fact]
    public void TestInput()
    {
        IEvent turn = new Piece();
        IExchange board = new Board();
        IExchange conversation = new Conversation();
        IExchange option = new Option();
        board.Children = [conversation];
        conversation.Children = [option];
        board.Selection = conversation;
        IPlayer io = new IO(board);
        StringReader sr = new("1");
        Console.SetIn(sr);

        io.Process(turn);

        Assert.Equal(option, conversation.Selection);
    }
}