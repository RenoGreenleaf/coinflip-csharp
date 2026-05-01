namespace CoinFlip.Engine.Interfaces;


/** <summary>Can be saved.</summary>*/
public interface IRelated
{
	/** <summary>Preserve current piece for further references.</summary> */
	void Persist(IDictionary<string, IPiece> relationships);
}