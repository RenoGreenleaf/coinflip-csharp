using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Editor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public ObservableCollection<IBranch> Board { get; }

    public MainWindowViewModel()
    {
        this.Board = [new Board() { Description = "Board" }];
    }
}
