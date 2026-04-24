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
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer io = new InputOutput(board, input, output);

        io.Process(turn);

        Assert.Equal(option, conversation.Selection);
    }
}