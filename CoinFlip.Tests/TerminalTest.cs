using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Tests;


public class TerminalTest
{
    [Fact]
    public void TestEmptyExchange()
    {
        IExchange piece = Piece_.Empty;
        IExchange related = new Piece_();

        piece.Description = "test";
        piece.Message = "test";
        piece.Children = [related];
        piece.Selection = related;
        piece.Hidden = true;

        Assert.Equal("", piece.Description);
        Assert.Equal("", piece.Message);
        Assert.Equal([], piece.Children);
        Assert.Equal(Piece_.Empty, piece.Selection);
        Assert.NotEqual(related, piece.Selection);
        Assert.False(piece.Hidden);
    }

    [Fact]
    public void TestConversation()
    {
        IExchange conversation = new Conversation();
        IExchange related = new Option();

        conversation.Children = [related];
        conversation.Selection = related;

        Assert.Equal([related], conversation.Children);
        Assert.Equal(related, conversation.Selection);
    }

    [Fact]
    public void TestConversation_UnrelatedOption()
    {
        IExchange conversation = new Conversation();
        IExchange unrelated = new Option();

        Assert.Throws<InvalidOperationException>(() => conversation.Selection = unrelated);
    }
}
