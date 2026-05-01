using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

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
}