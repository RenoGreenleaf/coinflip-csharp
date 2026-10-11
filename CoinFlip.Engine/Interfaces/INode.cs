using System.Collections.ObjectModel;
using CoinFlip.Engine.Players.AI;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Element of AI player reasoning.</summary> */
public interface INode
{
	string Header { get; }

	ObservableCollection<IConnector> Input { get; set; }

	ObservableCollection<IConnector> Output { get; set; }
}
