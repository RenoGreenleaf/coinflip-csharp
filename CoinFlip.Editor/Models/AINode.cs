using System.Collections.ObjectModel;
using Avalonia;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Players.AI;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CoinFlip.Editor.Models;

// Avalonia specific node wrapper.
public class AINode : INode, INotifyPropertyChanged
{
	public INode Wrapped { get; set; }

	public string Header { get => Wrapped.Header; }

	public Point Location
	{
		get
		{
			return new Point(Wrapped.X, Wrapped.Y);
		}
		set
		{
			Wrapped.X = value.X;
			Wrapped.Y = value.Y;
			OnPropertyChanged();
		}
	}

	public ObservableCollection<Connector> Input { get => Wrapped.Input; set => Wrapped.Input = value; }

	public ObservableCollection<Connector> Output { get => Wrapped.Output; set => Wrapped.Output = value; }

    public double X { get => Wrapped.X; set => Wrapped.X = value; }
    public double Y { get => Wrapped.Y; set => Wrapped.Y = value; }

	public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
