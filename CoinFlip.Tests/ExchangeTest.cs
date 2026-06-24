// Exchange is a kind of piece suited for use in CLI.
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Tests;


public class ExchangeTest
{
	[Fact]
	public void TestBoard()
	{
		Board piece = new();
		Conversation another = new();

		piece.Description = "description";
		piece.Intro = "message";
		piece.Children.Add(another);
		piece.Selection = another;

		Assert.Equal("description", piece.Description);
		Assert.Equal("message", piece.Intro);
		Assert.Equal([another], piece.Children);
		Assert.Equal(another, piece.Selection);
	}

	[Fact]
	public void TestConversations_CantAdd()
	{
		Conversations list = [];
		IBranch notConversation = new Board();

		Assert.Throws<ArgumentException>(() => list.Add(notConversation));
	}

	[Fact]
	public void TestConversations_CantInsert()
	{
		Conversation piece = new();
		Conversations list = [piece];
		IBranch notConversation = new Board();

		Assert.Throws<ArgumentException>(() => list[0] = notConversation);
		list[0] = piece;
	}

	[Fact]
	public void TestConversation()
	{
		Conversation piece = new();
		Option related = new();

		piece.Description = "Description.";
		piece.Intro = "Intro.";
		piece.Children.Add(related);
		piece.Selection = related;

		Assert.Equal("Description.", piece.Description);
		Assert.Equal("Intro.", piece.Intro);
		Assert.Equal([related], piece.Children);
		Assert.Equal(related, piece.Selection);
	}

	[Fact]
	public void TestOption()
	{
		Option piece = new();
		Option related = new();

		piece.Description = "description";
		piece.Message = "message";
		piece.Permanent = false;
		piece.Hidden = true;

		Assert.Equal("description", piece.Description);
		Assert.Equal("message", piece.Message);
		Assert.False(piece.Permanent);
		Assert.True(piece.Hidden);
		Assert.Throws<NotSupportedException>(() => piece.Children.Add(related));
	}

	[Fact]
	public void TestOptions_CantAdd()
	{
		Options list = [];
		IBranch notOption = new Board();

		Assert.Throws<ArgumentException>(() => list.Add(notOption));
	}

	[Fact]
	public void TestOptions_CantInsert()
	{
		Option piece = new();
		Options list = [piece];
		IBranch notOption = new Board();

		Assert.Throws<ArgumentException>(() => list[0] = notOption);
		list[0] = piece;
	}
}