namespace CoinFlip.Engine.Common.Interfaces;


/** <summary>Can be saved.</summary>*/
public interface IRelated
{
	/** <summary>Preserve current piece for further references.</summary> */
	void Persist(Dictionary<string, IRelated> relationships);
}