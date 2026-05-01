namespace CoinFlip.Engine.Interfaces;


/** <summary>Piece representation in terminal.</summary> */
public interface IExchange : IPiece
{
    /** <summary>Shown when a piece is previewed.</summary> */
    string Description { get; set; }

    /** <summary>Shown when a piece is selected.</summary> */
    string Message { get; set; }

    /** <summary>Whether to show a piece to a player.</summary> */
    bool Hidden { get; set; }

    /** <summary>Whether it can be selected multiple times.</summary> */
    bool Permanent { get; set; }

    /** <summary>Current child piece, if a piece has children.</summary> */
    IExchange Selection { get; set; }

    /** <summary>Conversations in a board, options in a conversation etc.</summary> */
    IList<IExchange> Children { get; set; }
}