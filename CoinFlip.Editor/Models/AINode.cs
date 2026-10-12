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
    ObservableCollection<IConnector> inputs = [];

    ObservableCollection<IConnector> outputs = [];

    public AINode(INode wrapped)
	{
        Wrapped = wrapped;

        foreach(IConnector connector in wrapped.Input)
        {
            inputs.Add(new AIConnector(connector));
        }

        foreach(IConnector connector in wrapped.Output)
        {
            outputs.Add(new AIConnector(connector));
        }
    }

	public INode Wrapped { get; set; }

	public string Header { get => Wrapped.Header; }

	public Point Location { get; set; }

	public ObservableCollection<IConnector> Input { get => inputs; set => Wrapped.Input = value; }

	public ObservableCollection<IConnector> Output { get => outputs; set => Wrapped.Output = value; }

	public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
