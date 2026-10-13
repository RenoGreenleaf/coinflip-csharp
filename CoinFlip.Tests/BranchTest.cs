using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Tests;


public class BranchTest
{
	[Fact]
	public void TestCanHaveChildren()
	{
		IBranch board = new Board();
		IBranch conversation = new Conversation();
		IBranch option = new Option();

		Assert.True(board.Fertile);
		Assert.True(conversation.Fertile);
		Assert.False(option.Fertile);
	}

	[Fact]
	public void TestNewChild()
	{
		Board board = new();
        Conversation conversation = new();
        Option option = new();

		board.NewChild();
		conversation.NewChild();
		option.NewChild();

		Assert.Single(board.Children);
		Assert.Single(conversation.Children);
		Assert.Empty(option.Children);
	}
}
