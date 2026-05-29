using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	string Name { get; set; }

	void VisitPiece(Piece piece);

	void VisitExchange(IExchange piece);
}
