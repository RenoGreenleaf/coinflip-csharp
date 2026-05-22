using System.Collections.ObjectModel;
using System.ComponentModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Board : Piece, IBranch
{
    private string description = "";

    private string intro = "";

    readonly Conversations children = [];

    public string Intro {
        get => intro;
        set
        {
            intro = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Intro)));
        }
    }

    public Conversation Selection { get; set; } = new();

    public IList<IBranch> Children { get => children; }

    public string Description {
        get => description;
        set
        {
            description = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void NewChild()
    {
        children.Add(new Conversation() { Description = "New conversation" });
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