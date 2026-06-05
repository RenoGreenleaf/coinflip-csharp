using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CoinFlip.Editor.ViewModels;
using System.Collections.Generic;
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

    public async Task Load()
    {
        FilePickerOpenOptions options = new() { AllowMultiple = false, };
        IReadOnlyList<IStorageFile> files = await this.StorageProvider.OpenFilePickerAsync(options);

        if (files.Count == 1 && ViewModel is not null)
        {
            DataContext = ViewModel.Load(files[0]);
        }
    }
}