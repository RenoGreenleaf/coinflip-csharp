using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;

namespace CoinFlip.Tests;


public class IOTest
{
    [Fact]
    public void TestInput()
    {
        IEvent turn = new Piece_();
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

    [Fact]
    public void TestOutput()
    {
        IEvent turn = new Piece_();
        IExchange board = new Board();
        IExchange conversation = new Conversation();
        IExchange option = new Option();
        option.Description = "Option one.";
        board.Children = [conversation];
        conversation.Children = [option];
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer io = new InputOutput(board, input, output);

        io.Process(turn);

        Assert.Equal("1. Option one.", output.ToString());
    }
}