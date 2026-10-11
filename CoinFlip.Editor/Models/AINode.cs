using System.Collections.ObjectModel;
using Avalonia;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Players.AI;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CoinFlip.Editor.Models;

// Avalonia specific node wrapper (adapter).
public class AINode : INode, INotifyPropertyChanged
{
	public INode Wrapped { get; set; }

	public string Header { get => Wrapped.Header; }

	public Point Location { get; set; }

	public ObservableCollection<IConnector> Input { get => Wrapped.Input; set => Wrapped.Input = value; }

	public ObservableCollection<IConnector> Output { get => Wrapped.Output; set => Wrapped.Output = value; }

	public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
