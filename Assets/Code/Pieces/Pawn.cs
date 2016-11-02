using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour, Piece {

    private Position position;
    private bool isWhite;
    private bool hasMoved;
    private bool isSelected;

    // Use this for initialization
    void Start () {
	    //figure out how to initalize the variables properly.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Returns true if piece is white.
    public bool IsWhite() {
        return isWhite;
    }

    //Gets the value of isSelected.
    public bool IsSelected() {
        return isSelected;
    }

    //Returns the type of piece in the form of a String.
    public string PieceType() {
        return "Pawn";
    }

    //Sets the piece to selected or not.
    public void SetSelected(bool pblnSelected) {
        isSelected = pblnSelected;
    }

    //Sets the position of the piece to reference in ValidMove()
    public void SetPosition(Position pposPosition) {
        position = pposPosition;
    }

    //Two different decision trees determinant on color of piece, because pawns only move in one direction. Returns true if the move is valid.
    public bool ValidMove(Piece[,] parrBoard, Position pposMoveTo) {
        if (isWhite) {
            if ((pposMoveTo.getX() == (position.getX() - 1) &&
                pposMoveTo.getY() == position.getY() - 1) &&
                parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                IsEnemy(parrBoard, pposMoveTo)) {
                hasMoved = true;
                return true;
            } else if ((pposMoveTo.getX() == (position.getX() + 1) &&
                  pposMoveTo.getY() == position.getY() - 1) &&
                  parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                  IsEnemy(parrBoard, pposMoveTo)) {
                hasMoved = true;
                return true;
            }

            if (hasMoved) {
                if (CheckSpace(parrBoard, pposMoveTo)) {
                    return true;
                }
            } else {
                if (CheckSpace(parrBoard, pposMoveTo) &&
                    ((pposMoveTo.getX() == position.getX() &&
                    pposMoveTo.getY() == position.getY() - 2) &&
                    parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] == null)) {
                    hasMoved = true;
                    return true;
                } else if (CheckSpace(parrBoard, pposMoveTo)) {
                    hasMoved = true;
                    return true;
                }
            }
        } else {
            if ((pposMoveTo.getX() == (position.getX() - 1) &&
                pposMoveTo.getY() == position.getY() + 1) &&
                parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                IsEnemy(parrBoard, pposMoveTo)) {
                hasMoved = true;
                return true;
            } else if ((pposMoveTo.getX() == (position.getX() + 1) &&
                  pposMoveTo.getY() == position.getY() + 1) &&
                  parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                  IsEnemy(parrBoard, pposMoveTo)) {
                hasMoved = true;
                return true;
            }

            if (hasMoved) {
                if (CheckSpace(parrBoard, pposMoveTo)) {
                    return true;
                }
            } else {
                if (CheckSpace(parrBoard, pposMoveTo) &&
                    ((pposMoveTo.getX() == position.getX() &&
                    pposMoveTo.getY() == position.getY() + 2) &&
                    parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] == null)) {
                    hasMoved = true;
                    return true;
                } else if (CheckSpace(parrBoard, pposMoveTo)) {
                    hasMoved = true;
                    return true;
                }
            }
        }
        return false;
    }

    //Checks if the space in front of the pawn is empty. Returns true if the space is empty.
    private bool CheckSpace(Piece[,] parrBoard, Position pposPosition) {
        if (isWhite) {
            if (pposPosition.getX() == position.getX() &&
                pposPosition.getY() < position.getY() &&
                Math.Abs(pposPosition.getY() - position.getY()) < 3 &&
                parrBoard[position.getX(), position.getY() - 1] == null) {
                return true;
            }
        } else {
            if (pposPosition.getX() == position.getX() &&
                pposPosition.getY() > position.getY() &&
                Math.Abs(pposPosition.getY() - position.getY()) < 3 &&
                parrBoard[position.getX(), position.getY() + 1] == null) {
                return true;
            }
        }

        return false;
    }

    //Determines if board space contains an enemy piece.
    private bool IsEnemy(Piece[,] parrBoard, Position pposPosition) {
        if (parrBoard[pposPosition.getX(), pposPosition.getY()].IsWhite() == "W" && isWhite) {
            return false;
        } else if (parrBoard[pposPosition.getX(), pposPosition.getY()].IsWhite() == "B" && !isWhite) {
            return false;
        }
        return true;
    }
}
