using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Board : Piece, IBranch
{
    readonly Conversations children = [];

    public string Intro { get; set; } = "";

    public Conversation Selection { get; set; } = new();

    public IList<IBranch> Children { get => children; }

    public string Description { get; set; } = "";
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