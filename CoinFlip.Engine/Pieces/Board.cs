using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Board : Piece, IBranch
{
    public string Intro = "";

    readonly Conversations children = [];

    Conversation selection = new();

    string description = "";

    public Conversation Selection
    {
        get => selection;
        set
        {
            if (!children.Contains(value))
            {
                throw new InvalidOperationException("Can't select unrelated pieces.");
            }

            selection = value;
        }
    }

    public IList<IBranch> Children { get => children; }

    public string Description { get => description; set => description = value; }
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