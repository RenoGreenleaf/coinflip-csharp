using CoinFlip.Engine.Common.Pieces;
using CoinFlip.Engine.Terminal.Interfaces;

namespace CoinFlip.Tests;


public class TerminalTest
{
    [Fact]
    public void TestEmptyExchange()
    {
        IExchange piece = Piece.Empty;
        IExchange related = new Piece();

        piece.Description = "test";
        piece.Message = "test";
        piece.Children = [related];
        piece.Selection = related;

        Assert.Equal("", piece.Description);
        Assert.Equal("", piece.Message);
        Assert.Equal([], piece.Children);
        Assert.Equal(Piece.Empty, piece.Selection);
        Assert.NotEqual(related, piece.Selection);
    }
}
