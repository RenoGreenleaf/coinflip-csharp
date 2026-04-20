using CoinFlip.Engine.Common.Interfaces;
using CoinFlip.Engine.Common.Pieces;
using Moq;

namespace CoinFlip.Tests;


public class CommonTest
{
    [Fact]
    public void TestEvent()
    {
        IEvent piece = new Piece();
        var player = new Mock<IPlayer>();

        piece.Subscribe(player.Object);
        piece.Trigger();

        player.Verify(x => x.Process(piece), Times.Once);
    }

    [Fact]
    public void TestEmptyRelation()
    {
        IRelated piece = new Piece();
        Dictionary<string, IRelated> relationships = [];

        piece.Persist(relationships);

        Assert.Equal([], relationships);
    }
}