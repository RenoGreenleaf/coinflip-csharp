using Avalonia.Controls;
using CoinFlip.Editor.ViewModels;

namespace CoinFlip.Editor.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}