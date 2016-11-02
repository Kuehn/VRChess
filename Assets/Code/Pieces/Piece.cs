using UnityEngine;
using System.Collections;

// This defines required methods for a piece.
public interface Piece {
    void SetPosition(Position pposPosition);

    void SetSelected(bool pblnSelected);

    bool IsSelected();

    bool IsWhite();

    string PieceType();

    bool ValidMove(Piece[,] parrBoard, Position pposPosition);
}
