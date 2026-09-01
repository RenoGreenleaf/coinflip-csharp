namespace CoinFlip.Engine.Interfaces;


/** <summary>Implementation of visitor pattern.</summary> */
public interface IPiece
{
	/** <summary>Allows finding individual pieces.</summary> */
	Guid ID { get; set; }

	/** <summary>Choose how a player should treat it.</summary> */
	void Accept(IPlayer player);
}