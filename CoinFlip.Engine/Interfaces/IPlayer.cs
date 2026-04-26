using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	void Process(IEvent @event); // TODO: remove

	void VisitPiece(Piece piece);
}
