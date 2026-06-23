using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;
using Avalonia.Platform.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoinFlip.Editor.ViewModels;

public partial class Game : ObservableObject
{
	private IBranch? currentPiece;

	private IPlayer? currentPlayer;

	public string Greeting { get; } = "Welcome to Avalonia!";

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

	public async Task Save(IStorageFile file)
	{
		await using Stream stream = await file.OpenWriteAsync();
		using StreamWriter streamWriter = new(stream);
		JsonSerializerOptions options = new()
		{
			WriteIndented = true,
			ReferenceHandler = ReferenceHandler.Preserve,
		};
		string json = JsonSerializer.Serialize(this, options);
		await streamWriter.WriteLineAsync(json);
	}

	public async Task<Game> Load(IStorageFile file)
	{
		await using Stream json = await file.OpenReadAsync();
		JsonSerializerOptions options = new()
		{
			ReferenceHandler = ReferenceHandler.Preserve,
		};

		Game? model = await JsonSerializer.DeserializeAsync<Game>(json, options);

		if (model is null)
		{
			throw new JsonException();
		}

		return model;
	}
}
