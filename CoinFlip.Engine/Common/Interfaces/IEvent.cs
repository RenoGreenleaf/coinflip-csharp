namespace CoinFlip.Engine.Common.Interfaces;


/** <summary>Animates players.</summary> */
public interface IEvent
{
	/** <summary>Make a player listen to it.</summary> */
	void Subscribe(IPlayer subscriber);

	/** <summary>Let listeners know that the event has occurred.</summary> */
	void Trigger();
}