using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Players.AI;

namespace CoinFlip.Engine.Pieces;


/** <summary>Can represent an actual conversation, location or context.</summary> */
public class Conversation : Piece, IBranch, INode
{
	private string description = "";

	private string intro = "";

	public string Intro {
		get => intro;
		set
		{
			intro = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Intro)));
		}
	}

	public string Description {
		get => description;
		set
		{
			description = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
		}
	}

	public Option Selection { get; set; } = new();

	public Options Children { get; set; } = new Options();

	public bool Fertile => true;

	public double X { get; set; }
	public double Y { get; set; }

	public ObservableCollection<Connector> Input { get; set; } = [];

	public ObservableCollection<Connector> Output { get; set; } = [];

    public string Header => description;

    public event PropertyChangedEventHandler? PropertyChanged;

	public T? FindChild<T>(Guid ID)
	{
		foreach (IBranch child in Children)
		{
			Debug.WriteLine(ID.ToString());

			if (child is T && child.ID == ID)
			{
				return (T) child;
			}

			T? grandchild = child.FindChild<T>(ID);

			if (grandchild is not null)
			{
				return grandchild;
			}
		}

		return default;
	}

	public void NewChild()
	{
		Children.Add(new Option() { Description = "New option" });
	}

	public bool RemoveChild(IBranch piece)
	{
		return Children.Remove(piece);
	}
}


public class Options : ObservableCollection<IBranch>
{
	protected override void InsertItem(int index, IBranch item)
	{
		Validate(item);
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, IBranch item)
	{
		Validate(item);
		base.SetItem(index, item);
	}

	void Validate(IBranch item)
	{
		if (item is not Option)
		{
			throw new ArgumentException("Conversation can contain only options.");
		}
	}
}
