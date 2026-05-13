using System.ComponentModel;
using CoinFlip.Engine.Interfaces;

namespace CoinFlip.Engine.Pieces;


public class Option : Piece, IBranch
{
    private string description = "";

    public string Description {
        get => description;
        set
        {
            description = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
        }
    }

    public string Message { get; set; } = "";

    public bool Hidden { get; set; } = false;

    public bool Permanent { get; set; } = true;

    public IList<IBranch> Children { get => Array.Empty<IBranch>(); }

    public event PropertyChangedEventHandler? PropertyChanged;
}