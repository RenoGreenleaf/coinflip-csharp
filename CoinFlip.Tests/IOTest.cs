using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;

namespace CoinFlip.Tests;


public class IOTest
{
    [Fact]
    public void TestInput()
    {
        IPiece turn = new Piece();
        IExchange board = new Board();
        IExchange conversation = new Conversation();
        IExchange option = new Option();
        board.Children = [conversation];
        conversation.Children = [option];
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal(option, conversation.Selection);
    }

    [Fact]
    public void TestOutput()
    {
        IPiece turn = new Piece();
        IExchange board = new Board();
        IExchange conversation = new Conversation();
        IExchange option = new Option();
        option.Description = "Option one.";
        board.Children = [conversation];
        conversation.Children = [option];
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal("1. Option one.", output.ToString());
    }
}