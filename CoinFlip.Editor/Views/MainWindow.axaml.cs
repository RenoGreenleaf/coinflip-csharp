using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.Base;
using System;
using CoinFlip.Engine;

namespace CoinFlip.Editor.Views;

public partial class MainWindow : Window
{
	public Game? ViewModel => DataContext as Game;

	public MainWindow()
	{
		InitializeComponent();
		DataContext = new Game();
		Opened += LoadInitially;
	}

	public async Task Save()
	{
		FilePickerSaveOptions options = new();
		IStorageFile? file = await this.StorageProvider.SaveFilePickerAsync(options);

		if (file is not null && ViewModel is not null)
		{
			await ViewModel.Save(await file.OpenWriteAsync());
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
			DataContext = await ViewModel.Load(await files[0].OpenReadAsync());
		} catch (JsonException error)
		{
			IMsBox<ButtonResult> popup = MessageBoxManager.GetMessageBoxStandard("Error", error.Message, ButtonEnum.Ok);
			await popup.ShowAsync();
		}
	}

	private async void LoadInitially(object? sender, EventArgs additional)
	{
		Opened -= LoadInitially;
		await Load();
	}
}