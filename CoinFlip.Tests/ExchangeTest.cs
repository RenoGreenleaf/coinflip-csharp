using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using NSubstitute;

namespace CoinFlip.Tests;


public class ExchangeTest
{
    [Fact]
    public void TestBoard()
    {
        IExchange piece = new Board();
        IExchange another = new Conversation();

        piece.Description = "description";
        piece.Message = "message";
        piece.Permanent = false;
        piece.Hidden = true;
        piece.Children = [another];
        piece.Selection = another;

        Assert.Equal("description", piece.Description);
        Assert.Equal("message", piece.Message);
        Assert.False(piece.Permanent);
        Assert.True(piece.Hidden);
        Assert.Equal([another], piece.Children);
        Assert.Equal(another, piece.Selection);
    }

    [Fact]
    public void TestBoard_OutsideSelection()
    {
        IExchange board = new Board();
        IExchange conversation = new Conversation();

        Assert.Throws<InvalidOperationException>(() => board.Selection = conversation);
    }

    [Fact]
    public void TestOption()
    {
        IExchange piece = new Option();
        IExchange related = new Option();

        piece.Description = "description";
        piece.Message = "message";
        piece.Permanent = false;
        piece.Hidden = true;
        piece.Children = [related];
        piece.Selection = related;

        Assert.Equal("description", piece.Description);
        Assert.Equal("message", piece.Message);
        Assert.False(piece.Permanent);
        Assert.True(piece.Hidden);
        Assert.Equal([], piece.Children);
        Assert.Equal(EmptyExchange.Instance, piece.Selection);
    }


    [Fact]
    public void TestEmpty()
    {
        EmptyExchange piece = EmptyExchange.Instance;
        IExchange related = new Option();
        IPlayer player = Substitute.For<IPlayer>();
        piece.Subscribe(player);

        piece.Description = "description";
        piece.Message = "message";
        piece.Permanent = false;
        piece.Hidden = true;
        piece.Children = [related];
        piece.Selection = related;
        piece.Trigger();

        Assert.Equal("", piece.Description);
        Assert.Equal("", piece.Message);
        Assert.True(piece.Permanent);
        Assert.False(piece.Hidden);
        Assert.Equal([], piece.Children);
        Assert.Equal(EmptyExchange.Instance, piece.Selection);
        player.DidNotReceive().VisitExchange(piece);
    }
}