namespace CoinFlip.Engine.AI.Interfaces;


/** <summary>Element of AI player reasoning.</summary> */
public interface INode
{
    /** <summary>Micro decision.</summary> */
	void Act(int input);
}