using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;

namespace CoinFlip.Tests;


[Collection("Sequential Tests")]
public class IOTest
{
	

	[Fact]
	public void TestExchange()
	{
		IPiece turn = new Piece();
		Board board = new() { Intro = "Intro" };
		Conversation conversation = new();
		Option option = new()
		{
			Description = "Option one.",
			Message = "Option one is selected."
		};
		board.Children.Add(conversation);
		conversation.Children.Add(option);
		board.Selection = conversation;
		using StringReader input = new("1");
		Console.SetIn(input);
		using StringWriter output = new();
		Console.SetOut(output);
		IPlayer player = new InputOutput() { Board = board };

		turn.Accept(player);

		Assert.Equal("Intro.\n\n1. Option one.\nOption one is selected.\n", output.ToString());
	}

	[Fact]
	public void TestHiddenOutput()
	{
		IPiece turn = new Piece();
		Board board = new();
		Conversation conversation = new();
		Option hidden = new() { Description = "Option one.", Hidden = true};
		Option shown = new() { Description = "Option two." };
		board.Children.Add(conversation);
		conversation.Children.Add(hidden);
		conversation.Children.Add(shown);
		board.Selection = conversation;
		using StringReader input = new("1");
		Console.SetIn(input);
		using StringWriter output = new();
		Console.SetOut(output);
		IPlayer player = new InputOutput() { Board = board };

		turn.Accept(player);

		Assert.Equal("1. Option two.\n\n", output.ToString());
	}

	[Fact]
	public void TestOptionless()
	{
		IPiece turn = new Piece();
		Board board = new() { Intro = "Intro" };
		Conversation conversation = new();
		board.Children.Add(conversation);
		board.Selection = conversation;
		using StringReader input = new("1");
		Console.SetIn(input);
		using StringWriter output = new();
		Console.SetOut(output);
		IPlayer player = new InputOutput() { Board = board };

		Assert.Throws<Exception>(() => turn.Accept(player));
	}

	[Theory]
	[InlineData("string\n1", "The choice should be a number.")]
	[InlineData("2\n1", "Item 2 is not in the list.")]
	public void TestIncorrectInput(string userInput, string userOutput)
	{
		IPiece turn = new Piece();
		Board board = new() { Intro = "Intro" };
		Conversation conversation = new();
		Option option = new() {Description = "Option one.", Message = "Over."};
		board.Children.Add(conversation);
		conversation.Children.Add(option);
		board.Selection = conversation;
		using StringReader input = new(userInput);
		Console.SetIn(input);
		using StringWriter output = new();
		Console.SetOut(output);
		IPlayer player = new InputOutput() { Board = board };

		turn.Accept(player);

		Assert.Equal($"Intro\n1. Option one.\n{userOutput}\n1. Option one.\nOver.\n", output.ToString());		
	}
}