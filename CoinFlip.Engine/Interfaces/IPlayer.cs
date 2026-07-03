using System.Text.Json.Serialization;
using CoinFlip.Engine.Pieces;
using CoinFlip.Engine.Players;
using Board_ = CoinFlip.Engine.Pieces.Board;

namespace CoinFlip.Engine.Interfaces;


[JsonPolymorphic]
[JsonDerivedType(typeof(InputOutput), "io")]
/** <summary>Uses a board.</summary> */
public interface IPlayer
{
	string Name { get; set; }

	[JsonIgnore]
	Board_ Board { set; }

	void VisitPiece(Piece piece);
}
