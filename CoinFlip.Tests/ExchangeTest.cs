using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using NSubstitute;

namespace CoinFlip.Tests;


public class ExchangeTest
{
    [Fact]
    public void TestBoard()
    {
        Board piece = new();
        Conversation another = new();

        piece.Description = "description";
        piece.Intro = "message";
        piece.Children.Add(another);
        piece.Selection = another;

        Assert.Equal("description", piece.Description);
        Assert.Equal("message", piece.Intro);
        Assert.Equal([another], piece.Children);
        Assert.Equal(another, piece.Selection);
    }

    [Fact]
    public void TestOption()
    {
        Option piece = new();
        Option related = new();

        piece.Description = "description";
        piece.Message = "message";
        piece.Permanent = false;
        piece.Hidden = true;
        piece.Children.Add(related);

        Assert.Equal("description", piece.Description);
        Assert.Equal("message", piece.Message);
        Assert.False(piece.Permanent);
        Assert.True(piece.Hidden);
        Assert.Equal([], piece.Children);
    }
}