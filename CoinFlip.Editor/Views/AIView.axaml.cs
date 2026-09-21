using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CoinFlip.Engine;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players.AI;

namespace CoinFlip.Editor.Views;

public partial class AIView : UserControl
{
    public AIView()
    {
        InitializeComponent();
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

		Player? player = DataContext as Player;

		if (player is null)
		{
			return;
		}

		MainWindow? window = TopLevel.GetTopLevel(this) as MainWindow;
		Game? game = window?.DataContext as Game;
		INode? piece = game?.Board[0]?.FindChild<INode>(nodeID);

		if (piece is null)
		{
			return;
		}

		player.Nodes.Add(piece);
	}
}