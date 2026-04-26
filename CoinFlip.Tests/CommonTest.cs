using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
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
    public void TestEvent_Unsubscribe()
    {
        IEvent piece = new Piece();
        IPlayer player = Substitute.For<IPlayer>();

        piece.Subscribe(player);
        piece.Unsubscribe(player);
        piece.Trigger();

        player.Received(0).Process(piece);
    }


    [Fact]
    public void TestEvent_UnsubscribeDuringTrigger() {
        IEvent piece = new Piece();
        IPlayer player1 = Substitute.For<IPlayer>();
        IPlayer player2 = Substitute.For<IPlayer>();
        player1.When(x => x.Process(Arg.Any<IEvent>())).Do(_ => piece.Unsubscribe(player2));
    
        piece.Subscribe(player1);
        piece.Subscribe(player2);
        piece.Trigger(); // shouldn't throw an exception.
    }

    [Fact]
    public void TestEmptyEvent_Unsubscribe()
    {
        IEvent piece = Piece.Empty;
        IPlayer player1 = Substitute.For<IPlayer>();
        IPlayer player2 = Substitute.For<IPlayer>();

        piece.Subscribe(player1);
        piece.Subscribe(player2);
        piece.Unsubscribe(player2);
        piece.Trigger();

        player1.Received(0).Process(piece);
    }

    [Fact]
    public void TestEvent_UnsubscribeUnknown()
    {
        IEvent piece = new Piece();
        IPlayer player = Substitute.For<IPlayer>();
    
        piece.Unsubscribe(player); // should stay silent.
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
        board.Hidden = true;

        Assert.Equal("description", board.Description);
        Assert.Equal("message", board.Message);
        Assert.Equal([conversation], board.Children);
        Assert.Equal(conversation, board.Selection);
        Assert.True(board.Hidden);
    }

    [Fact]
    public void TestBoardForTerminal_OutsideSelection()
    {
        IExchange board = new Board();
        IExchange conversation = new Conversation();

        Assert.Throws<InvalidOperationException>(() => board.Selection = conversation);
    }
}