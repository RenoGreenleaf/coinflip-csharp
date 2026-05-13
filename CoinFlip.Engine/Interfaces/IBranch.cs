using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CoinFlip.Engine.Interfaces;


/** <summary>Representation for a tree branch in the editor.</summary> */
public interface IBranch : INotifyPropertyChanged
{
    /** <summary>Displayed as a label.</summary> */
    string Description { get; }

    /** <summary>Use ObservableCollection as IList to keep things up to date.</summary> */
    IList<IBranch> Children { get; }
}