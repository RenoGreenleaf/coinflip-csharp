using System.Collections.ObjectModel;
using System.ComponentModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


/** <summary>Can represent an actual conversation, location or context.</summary> */
public class Conversation : Piece, IBranch
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

	public event PropertyChangedEventHandler? PropertyChanged;

	public T? FindChild<T>(Guid ID)
	{
		throw new NotImplementedException();
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