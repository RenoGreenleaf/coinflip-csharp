namespace CoinFlip.Engine.Terminal.Interfaces;


/** <summary>Piece representation in terminal.</summary> */
public interface IExchange
{
    /** <summary>Shown when a piece is previewed.</summary> */
    string Description { get; set; }

    /** <summary>Shown when a piece is selected.</summary> */
    string Message { get; set; }

    /** <summary>Current child piece, if a piece has children.</summary> */
    IExchange Selection { get; set; }

    /** <summary>Conversations in a board, options in a conversation etc.</summary> */
    IList<IExchange> Children { get; set; }
}