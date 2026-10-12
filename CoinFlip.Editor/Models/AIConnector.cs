namespace CoinFlip.Editor.Models;

using Avalonia;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Players.AI;

// Avalonia specific connector (adapter).
public class AIConnector(IConnector adapted) : IConnector
{
	public string Title { get => adapted.Title; set => adapted.Title = value; }

    public Point Anchor { get; set; } = new();
}
