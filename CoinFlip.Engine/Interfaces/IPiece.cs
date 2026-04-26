namespace CoinFlip.Engine.Interfaces;


/** <summary>Implementation of visitor pattern.</summary> */
public interface IPiece
{
    void Accept(IPlayer player);
}