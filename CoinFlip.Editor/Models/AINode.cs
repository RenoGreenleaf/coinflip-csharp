using System.Collections.ObjectModel;
using Avalonia;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Players.AI;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoinFlip.Editor.Models;

// Avalonia specific node wrapper.
public class AINode(INode node) : INode, INotifyPropertyChanged
{
	public string Header { get => node.Header; }

	public Point Location
	{
		get
		{
			return new Point(node.X, node.Y);
		}
		set
		{
			node.X = value.X;
			node.Y = value.Y;
			OnPropertyChanged();
		}
	}

	public ObservableCollection<Connector> Input { get => node.Input; set => node.Input = value; }

	public ObservableCollection<Connector> Output { get => node.Output; set => node.Output = value; }

    public double X { get => node.X; set => node.X = value; }
    public double Y { get => node.Y; set => node.Y = value; }

	public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
