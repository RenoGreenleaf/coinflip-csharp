using CoinFlip.Engine.AI.Interfaces;
using CoinFlip.Engine.Common.Interfaces;
using CoinFlip.Engine.Common.Pieces;
using CoinFlip.Engine.Terminal.Interfaces;
using NSubstitute;

namespace CoinFlip.Tests;


public class CommonTest
{
    [Fact]
    public void TestEmptyEvent()
    {
        IEvent piece = Piece.Empty;
        IPlayer player = Substitute.For<IPlayer>();

        piece.Subscribe(player);
        piece.Trigger();

        player.Received(0).Process(piece);
    }

    [Fact]
    public void TestEvent()
    {
        IEvent piece = new Piece();
        IPlayer player = Substitute.For<IPlayer>();

        piece.Subscribe(player);
        piece.Trigger();

        player.Received(1).Process(piece);
    }

    [Fact]
    public void TestEmptyRelation()
    {
        IRelated piece = new Piece();
        Dictionary<string, IRelated> relationships = [];

        piece.Persist(relationships);

        Assert.Equal([], relationships);
    }

    [Theory]
    [InlineData([0])]
    [InlineData([1])]
    public void TestEmptyAINode(int input)
    {
        INode piece = Piece.Empty;

        piece.Act(input);

        // TODO: figure out how to check if Act() does nothing.
    }

    [Fact]
    public void TestBoardForTerminal()
    {
        IExchange board = new Board();
        IExchange conversation = new Conversation();

        board.Description = "description";
        board.Message = "message";
        board.Children.Add(conversation);
        board.Selection = conversation;

        Assert.Equal("description", board.Description);
        Assert.Equal("message", board.Message);
        Assert.Equal([conversation], board.Children);
        Assert.Equal(conversation, board.Selection);
    }

    [Fact]
    public void TestBoardExchangeForTerminal_OutsideSelection()
    {
        IExchange board = new Board();
        IExchange conversation = new Conversation();

        Assert.Throws<InvalidOperationException>(() => board.Selection = conversation);
    }
}