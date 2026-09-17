using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
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
using Avalonia.Interactivity;
using Avalonia;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Editor.Views;

public partial class MainWindow : Window
{
	PotentialDrag? potentialDrag;

	public Game? ViewModel => DataContext as Game;

	public MainWindow()
	{
		InitializeComponent();
		DataContext = new Game();
		Opened += LoadInitially;
		Board.AddHandler(
			PointerPressedEvent,
			SupposedDrag,
			RoutingStrategies.Tunnel | RoutingStrategies.Bubble
		);
		Board.AddHandler(
			PointerMovedEvent,
			Drag
		);
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

	async void LoadInitially(object? sender, EventArgs additional)
	{
		Opened -= LoadInitially;
		await Load();
	}

	async void SupposedDrag(object? sender, PointerPressedEventArgs @event)
	{
		if (!@event.GetCurrentPoint(null).Properties.IsLeftButtonPressed)
		{
			return;
		}

		Visual? source = @event.Source as Visual;
		TreeViewItem? treeItem = source?.FindAncestorOfType<TreeViewItem>(includeSelf: true);

		if (treeItem?.DataContext is not IPiece piece)
		{
			return;
		}

		potentialDrag = new()
		{
			Piece = piece,
			StartPosition = @event.GetPosition(Board),
			Threshold = 7,
			Event = @event,
		};
	}

	async void Drag(object? sender, PointerEventArgs @event)
	{
		if (potentialDrag is null)
		{
			return;
		}

		PotentialDrag drag = potentialDrag.Value;

		if (!@event.GetCurrentPoint(Board).Properties.IsLeftButtonPressed)
		{
			potentialDrag = null;
			return;
		}

		Point delta = @event.GetPosition(Board) - drag.StartPosition;

		if (Math.Abs(delta.X) < drag.Threshold && Math.Abs(delta.Y) < drag.Threshold)
		{
			return;
		}

		potentialDrag = null;		
		DataTransfer transfer = new();
		DataTransferItem transferItem = new();
		transferItem.SetText(drag.Piece.ID.ToString());
		transfer.Add(transferItem);

		await DragDrop.DoDragDropAsync(
			drag.Event,
			transfer,
			DragDropEffects.Copy
		);		
	}
}


public struct PotentialDrag
{
	public IPiece Piece;
	public Point StartPosition;
	public double Threshold;
	public PointerPressedEventArgs Event;
}