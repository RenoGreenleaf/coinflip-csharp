namespace CoinFlip.Editor.Models;

using Avalonia;
using CoinFlip.Engine.Interfaces;

// Avalonia specific connector (adapter).
public class AIConnector : IConnector
{
    public string Title { get; set; } = "";

    public Point Anchor { get; set; } = new();
}
