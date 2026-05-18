using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Editor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private IBranch? currentPiece;

    public string Greeting { get; } = "Welcome to Avalonia!";

    public ObservableCollection<IBranch> Board { get; }

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

    public MainWindowViewModel()
    {
        IBranch conversation = new Conversation();
        IBranch option = new Option();
        IBranch board = new Board () { Description = "World" };
        board.Children.Add(conversation);
        conversation.Children.Add(option);
        this.Board = [board];
        CurrentPiece = option;
    }
}
