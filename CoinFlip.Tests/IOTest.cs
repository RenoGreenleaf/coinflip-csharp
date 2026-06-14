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
        Board board = new();
        Conversation conversation = new();
        Option option = new();
        board.Children.Add(conversation);
        conversation.Children.Add(option);
        board.Selection = conversation;
        StringReader input = new("1\n");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal(option, conversation.Selection);
    }

    [Fact]
    public void TestOutput()
    {
        IPiece turn = new Piece();
        Board board = new();
        Conversation conversation = new();
        Option option = new();
        option.Description = "Option one.";
        board.Children.Add(conversation);
        conversation.Children.Add(option);
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal("1. Option one.\n", output.ToString());
    }

    [Fact]
    public void TestHiddenOutput()
    {
        IPiece turn = new Piece();
        Board board = new();
        Conversation conversation = new();
        Option option = new();
        option.Description = "Option one.";
        option.Hidden = true;
        board.Children.Add(conversation);
        conversation.Children.Add(option);
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal("", output.ToString());
    }
}