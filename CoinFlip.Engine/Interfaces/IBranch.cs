using System.Collections.ObjectModel;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Representation for a tree branch in the editor.</summary> */
public interface IBranch
{
    /** <summary>Displayed as a label.</summary> */
    string Description { get; set; }

    /** <summary>Main thing to form a tree.</summary> */
    ObservableCollection<IBranch> Children { get; set; }
}