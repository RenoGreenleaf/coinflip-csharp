using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Makes changes to a board.</summary> */
public interface IDecision
{
    void Apply(IPiece board);
}