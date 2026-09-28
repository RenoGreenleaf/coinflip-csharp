using System.Collections.ObjectModel;
using CoinFlip.Engine.Players.AI;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Element of AI player reasoning.</summary> */
public interface INode
{
	string Header { get; }
	double X { get; set; }
	double Y { get; set; }

	ObservableCollection<Connector> Input { get; set; }

	ObservableCollection<Connector> Output { get; set; }
}
