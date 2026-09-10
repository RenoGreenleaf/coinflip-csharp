using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

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

		Console.Out.WriteLine("Test");
		// TODO: find piece by ID and make current player track it
	}
}