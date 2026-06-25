using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Makes changes to a board.</summary> */
public interface IDecision
{
	/** <summary>After a decision is made, apply it.</summary> */
	void Apply(Board board);
}