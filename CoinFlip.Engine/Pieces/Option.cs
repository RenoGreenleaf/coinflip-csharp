using System.Collections.ObjectModel;
using System.ComponentModel;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Players.AI;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece, IBranch, INode
{
	private string description = "";

	private string message = "";

	private bool hidden = false;

	private bool permanent = true;

	public string Description {
		get => description;
		set
		{
			description = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
		}
	}

	public string Message {
		get => message;
		set
		{
			message = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
		}
	}

	public bool Hidden {
		get => hidden;
		set
		{
			hidden = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hidden)));
		}
	}

	public bool Permanent {
		get => permanent;
		set
		{
			permanent = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Permanent)));
		}
	}

	public IList<IBranch> Children { get => Array.Empty<IBranch>(); }

	public bool Fertile => false;

	public string Title => description;

	public ObservableCollection<Connector> Input { get; set; } = [];

	public ObservableCollection<Connector> Output { get; set; } = [];
	public Guid ID { get; set; } = Guid.CreateVersion7();

	public event PropertyChangedEventHandler? PropertyChanged;

	public void NewChild() {}

	public bool RemoveChild(IBranch piece) => false;
}