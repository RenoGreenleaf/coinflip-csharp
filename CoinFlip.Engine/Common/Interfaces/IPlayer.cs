namespace CoinFlip.Engine.Common.Interfaces;


/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	/** <summary>Make a turn.</summary> */
	 void Process(IEvent anEvent);
}
