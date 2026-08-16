using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;
using Board_ = CoinFlip.Engine.Pieces.Board;

namespace CoinFlip.Engine.Players;


public class AI : IPlayer
{
	Board_ board = Board_.Empty;

	public string Name { get; set; } = "";

	public Board Board { set => board = value; }

	public void VisitPiece(Piece piece)
	{
		throw new NotImplementedException();
	}
}