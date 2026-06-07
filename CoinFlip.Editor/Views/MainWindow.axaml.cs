using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CoinFlip.Editor.ViewModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.Base;
using System.Text.Json.Serialization;

namespace CoinFlip.Editor.Views;

public partial class MainWindow : Window
{
    public Game? ViewModel => DataContext as Game;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new Game();
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

        if (files.Count != 1 || ViewModel is null)
        {
            return;
        }

        try {
            DataContext = await ViewModel.Load(files[0]);
        } catch (JsonException error)
        {
            IMsBox<ButtonResult> popup = MessageBoxManager.GetMessageBoxStandard("Error", error.Message, ButtonEnum.Ok);
            await popup.ShowAsync();
        }
    }
}