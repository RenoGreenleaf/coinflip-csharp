using System.Collections.ObjectModel;
using CoinFlip.Engine.Players.AI;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Element of AI player reasoning.</summary> */
public interface INode
{
	Guid ID {get; set; }

	string Title { get; }

	ObservableCollection<Connector> Input { get; set; }

	ObservableCollection<Connector> Output { get; set; }
}