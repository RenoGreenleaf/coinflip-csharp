using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CoinFlip.Editor.Models;
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
		if (sender is not Control || sender is null)
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

		if (game?.Board[0] is not IBranch root)
		{
			throw new Exception();
		}

		INode? piece;

		if (root is INode && nodeID == root.ID)
		{
			piece = (INode) root;
		} else {
			piece = root.FindChild<INode>(nodeID);
		}

		if (piece is null)
		{
			return;
		}

		Point point = @event.GetPosition((Visual)sender);
		AINode node = new(piece);
		node.Location = point;
		player.Nodes.Add(node);
	}
}
