using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CoinFlip.Engine.Pieces;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CoinFlip.Engine.Players;

namespace CoinFlip.Engine;

/** <summary>Board, players and decisions together form a game.</summary> */
public partial class Game : ObservableObject
{
	public Game()
	{
		DeletePiece = new RelayCommand<IBranch>(Remove);
		DeletePlayer = new RelayCommand<IPlayer>(Remove);
		CreatePlayer = new RelayCommand<string>(NewPlayer);
	}


	public ICommand DeletePiece { get; }

	public ICommand DeletePlayer { get; }

	public ICommand CreatePlayer { get; }

	private IBranch? currentPiece;

	private IPlayer? currentPlayer;

	public ObservableCollection<IBranch> Board { get; set; } = [new Board() { Description = "Board" }];

	[JsonIgnore]
	public IBranch? CurrentPiece {
		get => currentPiece;
		set
		{
			if (currentPiece != value)
			{
				currentPiece = value;
				OnPropertyChanged();
			}
		}
	}

	public ObservableCollection<IPlayer> Players { get; set; } = [];

	[JsonIgnore]
	public IPlayer? CurrentPlayer
	{
		get => currentPlayer;
		set
		{
			if (currentPlayer != value)
			{
				currentPlayer = value;
				OnPropertyChanged();
			}
		}
	}

	public async Task Save(Stream file)
	{
		using StreamWriter streamWriter = new(file);
		JsonSerializerOptions options = new()
		{
			WriteIndented = true,
			ReferenceHandler = ReferenceHandler.Preserve,
		};
		string json = JsonSerializer.Serialize(this, options);
		await streamWriter.WriteLineAsync(json);
	}

	public async Task<Game> Load(Stream json)
	{
		JsonSerializerOptions options = new()
		{
			ReferenceHandler = ReferenceHandler.Preserve,
		};

		Game? model = await JsonSerializer.DeserializeAsync<Game>(json, options);

		if (model is null)
		{
			throw new JsonException();
		}

		foreach (IPlayer player in model.Players)
		{
			player.Board = (Board) model.Board[0];
		}

		return model;
	}

	public void Play()
	{
		Piece turn = new();

		foreach (IPlayer player in Players)
		{
			turn.Subscribe(player);
		}

		while (true)
		{
			turn.Trigger();
		}
	}

	void Remove(IBranch? piece)
	{
		if (piece is null)
		{
			return;
		}
	
		if (currentPiece == piece)
		{
			CurrentPiece = null;
		}

		Board[0].RemoveChild(piece);
	}

	void Remove(IPlayer? player)
	{
		if (player is null)
		{
			return;
		}

		Players.Remove(player);

		if (currentPlayer == player)
		{
			CurrentPlayer = null;
		}
	}

	void NewPlayer(string? type)
	{
		if (type is null)
		{
			throw new Exception();
		}

		IPlayer player = type switch
		{
			"IO" => new InputOutput(),
			"AI" => new AI(),
			_ => throw new Exception(), // TODO: set to empty player
		};
		player.Name = type;
		Players.Add(player);
		CurrentPlayer = player;
	}
}
