using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using System.Collections.ObjectModel;
using Board_ = CoinFlip.Engine.Pieces.Board;

namespace CoinFlip.Engine.Players.AI;


public class Player : IPlayer
{
	Board_ board = Board_.Empty;

	public string Name { get; set; } = "AI";

	public Board Board { set => board = value; }

	public ObservableCollection<INode> Nodes { get; } = [];

	public void VisitPiece(Piece piece)
	{
		throw new NotImplementedException();
	}
}