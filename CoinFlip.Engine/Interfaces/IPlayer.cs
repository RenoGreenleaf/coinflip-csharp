using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	void VisitPiece(Piece piece);

	void VisitExchange(IExchange piece);
}
