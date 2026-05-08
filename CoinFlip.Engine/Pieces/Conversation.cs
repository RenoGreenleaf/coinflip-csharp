using System.Collections.ObjectModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Conversation : IBranch
{
    public string Intro = "";

    readonly Options children = [];

    Option selection = new();

    string description = "";

    public Option Selection
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