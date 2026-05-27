using Avalonia.Controls;
using CoinFlip.Editor.ViewModels;
using System.ComponentModel;
using System.Linq;

namespace CoinFlip.Editor.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}