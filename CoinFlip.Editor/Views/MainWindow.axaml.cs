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

    /** <summary>Hide empty menu.</summary> */
    public void OnContextMenu_Opening(object? sender, CancelEventArgs e)
    {
        if (sender is not ContextMenu menu)
            return;

        bool hasVisibleItems = menu.Items
            .OfType<MenuItem>()
            .Any(x => x.IsVisible);

        e.Cancel = !hasVisibleItems;
    }
}