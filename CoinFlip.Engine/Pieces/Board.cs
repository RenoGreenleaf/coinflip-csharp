using System.Collections.ObjectModel;
using System.ComponentModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


/** <summary>Root board piece.</summary> */
public class Board : Piece, IBranch
{
	public static Board Empty = new();

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

	public Conversation Selection { get; set; } = new();

	public IList<IBranch> Children { get; set; } = [];

	public string Description {
		get => description;
		set
		{
			description = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
		}
	}

	public bool Fertile => true;

	public event PropertyChangedEventHandler? PropertyChanged;

	public void NewChild()
	{
		Children.Add(new Conversation() { Description = "New conversation" });
	}
}


public class Conversations : ObservableCollection<IBranch>
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
		if (item is not Conversation)
		{
			throw new ArgumentException("Board can contain only conversations.");
		}
	}
}