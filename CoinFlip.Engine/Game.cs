using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine;

/** <summary>Container for BPD elements.</summary> */
public partial class Game : ObservableObject
{
	private IBranch? currentPiece;

	private IPlayer? currentPlayer;

	public ObservableCollection<IBranch> Board { get; set; } = [];

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
}
