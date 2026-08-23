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
using Avalonia.Input;
using CoinFlip.Engine.Interfaces;

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

	private async void Drag(object? sender, PointerPressedEventArgs @event)
	{
		if (!@event.GetCurrentPoint(null).Properties.IsLeftButtonPressed)
		{
			return;
		}

		if (sender is not TreeViewItem item || item.DataContext is not INode node)
		{
			return;
		}

		DataTransfer transfer = new();
		DataTransferItem transferItem = new();
		transferItem.SetText(node.ID.ToString());
		transfer.Add(transferItem);

		await DragDrop.DoDragDropAsync(
			@event,
			transfer,
			DragDropEffects.Copy
		);
	}

	private void DragOver(object? sender, DragEventArgs @event)
	{
		@event.DragEffects = DragDropEffects.Copy;
	}

	private void Drop(object? sender, DragEventArgs @event)
	{
		if (sender is not Control)
		{
			return;
		}

		string rawNodeID = @event.DataTransfer.TryGetText() ?? "";

		if (!Guid.TryParse(rawNodeID, out Guid nodeID))
		{
			return;
		}

		// TODO: find piece by ID and make current player track it
	}
}