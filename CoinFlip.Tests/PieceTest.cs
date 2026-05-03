using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using NSubstitute;

namespace CoinFlip.Tests;


public class PieceTest
{
    [Fact]
    public void TestSubscription()
    {
        Piece turn = new();
        IPlayer player = Substitute.For<IPlayer>();

        turn.Subscribe(player);
        turn.Trigger();

        player.Received(1).VisitPiece(turn);
    }

    [Fact]
    public void TestUnsubscription()
    {
        Piece turn = new();
        IPlayer player = Substitute.For<IPlayer>();
        turn.Subscribe(player);

        turn.Unsubscribe(player);
        turn.Trigger();

        player.Received(0).VisitPiece(turn);
    }

    [Fact]
    public void TestUnsubscribeDuringTrigger() {
        Piece piece = new();
        IPlayer player1 = Substitute.For<IPlayer>();
        IPlayer player2 = Substitute.For<IPlayer>();
        IPlayer player3 = Substitute.For<IPlayer>();
        player1.When(player => player.VisitPiece(Arg.Any<Piece>())).Do(_ => piece.Unsubscribe(player2));
    
        piece.Subscribe(player1);
        piece.Subscribe(player2);
        piece.Subscribe(player3);
        piece.Trigger(); // shouldn't throw an exception.
    }

    [Fact]
    public void TestEvent_UnsubscribeUnknown()
    {
        Piece piece = new();
        IPlayer player = Substitute.For<IPlayer>();
    
        piece.Unsubscribe(player); // should stay silent.
    }
}