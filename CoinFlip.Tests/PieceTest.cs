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
}