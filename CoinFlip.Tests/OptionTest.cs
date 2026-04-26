using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Tests;


public class OptionTest
{
    [Fact]
    public void TestLeaf()
    {
        IExchange option = new Option();
        IExchange related = new Piece_();

        option.Children = [related];
        option.Selection = related;

        Assert.Equal([], option.Children);
        Assert.Equal(Piece_.Empty, option.Selection);
    }
}