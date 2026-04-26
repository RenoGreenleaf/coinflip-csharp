namespace CoinFlip.Engine.Interfaces;


/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	void Process(IEvent player); // TODO: remove

	void VisitEvent(Event piece);
}
