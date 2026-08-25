namespace CoinFlip.Engine.Interfaces;


/** <summary>Implementation of visitor pattern.</summary> */
public interface IPiece
{
	Guid ID { get; set; }

	void Accept(IPlayer player);
}