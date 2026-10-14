namespace CoinFlip.Engine.Players.AI;

using CoinFlip.Engine.Interfaces;

public class Connection
{
    public IConnector Source { get; set; } = new Connector();

    public IConnector Target { get; set; } = new Connector();
}
