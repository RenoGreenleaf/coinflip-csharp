using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;

namespace CoinFlip.Tests;


public class IOTest
{
    [Fact]
    public void TestExchange()
    {
        IPiece turn = new Piece();
        Board board = new();
        Conversation conversation = new();
        Option option = new();
        option.Description = "Option one.";
        option.Message = "Option one is selected.";
        board.Children.Add(conversation);
        conversation.Children.Add(option);
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal("1. Option one.\nOption one is selected.\n", output.ToString());
    }

    [Fact]
    public void TestHiddenOutput()
    {
        IPiece turn = new Piece();
        Board board = new();
        Conversation conversation = new();
        Option hidden = new() { Description = "Option one.", Hidden = true};
        Option shown = new() { Description = "Option two." };
        board.Children.Add(conversation);
        conversation.Children.Add(hidden);
        conversation.Children.Add(shown);
        board.Selection = conversation;
        StringReader input = new("1");
        StringWriter output = new();
        IPlayer player = new InputOutput(board, input, output);

        turn.Accept(player);

        Assert.Equal("1. Option two.\n\n", output.ToString());
    }
}