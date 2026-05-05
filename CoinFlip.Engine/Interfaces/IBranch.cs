namespace CoinFlip.Engine.Interfaces;


/** <summary>Representation for a tree branch in the editor.</summary> */
public interface IBranch
{
    /** <summary>Displayed as label.</summary> */
    string Description { get; set; }

    IList<IBranch> Children { get; set; }
}