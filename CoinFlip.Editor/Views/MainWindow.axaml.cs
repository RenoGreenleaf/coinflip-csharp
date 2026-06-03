using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CoinFlip.Editor.ViewModels;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoinFlip.Editor.Views;

public partial class MainWindow : Window
{
    public MainWindowViewModel? ViewModel => DataContext as MainWindowViewModel;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    public async Task Save()
    {
        FilePickerSaveOptions options = new();
        IStorageFile? file = await this.StorageProvider.SaveFilePickerAsync(options);

        if (file is not null && ViewModel is not null)
        {
            await ViewModel.Save(file);
        }
    }
}