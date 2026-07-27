using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Serialization;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Engine.Interfaces;


[JsonPolymorphic]
[JsonDerivedType(typeof(Option), "option")]
[JsonDerivedType(typeof(Board), "board")]
[JsonDerivedType(typeof(Conversation), "conversation")]
/** <summary>Representation for a tree branch in the editor.</summary> */
public interface IBranch : INotifyPropertyChanged
{
	/** <summary>Displayed as a label.</summary> */
	string Description { get; }

	void NewChild();

	bool Fertile { get; }
}