using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Editor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public ObservableCollection<IBranch> Board { get; }

    public IPiece CurrentPiece { get; set; }

    public MainWindowViewModel()
    {
        IBranch conversation = new Conversation();
        IBranch board = new Board () { Description = "World" };
        board.Children.Add(conversation);
        this.Board = [board];
        CurrentPiece = (IPiece) conversation;
    }
}
