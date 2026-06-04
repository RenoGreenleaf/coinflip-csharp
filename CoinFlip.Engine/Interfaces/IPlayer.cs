using System.Text.Json.Serialization;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;

namespace CoinFlip.Engine.Interfaces;


[JsonPolymorphic]
[JsonDerivedType(typeof(InputOutput), "io")]
/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	string Name { get; set; }

	void VisitPiece(Piece piece);

	void VisitExchange(IExchange piece);
}
