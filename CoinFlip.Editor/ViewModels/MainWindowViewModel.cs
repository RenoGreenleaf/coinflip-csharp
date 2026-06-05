using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Controls;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using System.Linq;
using System.Collections.Generic;
using CoinFlip.Engine.Players;
using System;
using Avalonia.Platform.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CoinFlip.Editor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private IBranch? currentPiece;

    private IPlayer? currentPlayer;

    public string Greeting { get; } = "Welcome to Avalonia!";

    public ObservableCollection<IBranch> Board { get; }

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

    public ObservableCollection<IPlayer> Players { get; }

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

    public MainWindowViewModel Load(IStorageFile file)
    {
        System.Console.WriteLine("Loading");
        return new MainWindowViewModel();
    }

    public MainWindowViewModel()
    {
        IBranch conversation = new Conversation();
        IBranch option = new Option();
        IBranch board = new Board () { Description = "World" };
        IPlayer io = new InputOutput((Board) board, Console.In, Console.Out) { Name = "IO" };
        board.Children.Add(conversation);
        conversation.Children.Add(option);
        this.Board = [board];
        CurrentPiece = board;
        Players = [io];
    }
}
