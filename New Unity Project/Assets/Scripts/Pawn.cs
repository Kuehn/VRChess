using UnityEngine;
using System.Collections;
using System;

public class Pawn : MonoBehaviour, Piece
{
    private GameObject objCollider;
    private Position position;
    private bool isWhite;
    private bool hasMoved;
    private bool isSelected;
    private string strEnPassant;
    private bool blnMoveTwo;

    private Tile tempTile; //Holds the latest tile that the pawn has bumped into

    private float x; 
    private float y;
    private float z;

   

    public GameObject pwn;

    public static Pawn Create()
    {
        GameObject newObject = Instantiate(Resources.Load("Prefabs/Pawn")) as GameObject;
        // Instantiate(pwn, Transform.position, Transform.rotation);
        Pawn pawn = newObject.GetComponent<Pawn>();
        return pawn;
    }

    public Pawn(bool isWhite, Position position)
    {
        this.isWhite = isWhite;
        this.position = position;
    }
    // Use this for initialization
    void Start()
    {
        //figure out how to initalize the variables properly.
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setWhite(bool isWhite)
    {
        this.isWhite = isWhite;
    }


    //Returns true if piece is white.
    public bool IsWhite()
    {
        return isWhite;
    }

    //Gets the value of isSelected.
    public bool IsSelected()
    {
        return isSelected;
    }

    //Returns the type of piece in the form of a String.
    public string PieceType()
    {
        return "Pawn";
    }

    //Sets the piece to selected or not.
    public void SetSelected(bool pblnSelected)
    {
        isSelected = pblnSelected;
    }

    //Sets the position of the piece to reference in ValidMove()
    public void SetPosition(Position pposPosition)
    {
        position = pposPosition;
    }

    public Vector3 getPositionMovingTo()
    {
        Vector3 newPos = this.transform.position;
        newPos.x = x;
        newPos.y = y;
        newPos.z = z;
        return newPos;
    }


    //Check if the piece is collided with a tile, if it is then center it correctly and set position
    public void MovePieceToTile()
    {
        Vector3 newPos = this.transform.position;
        newPos.x = x;
        newPos.y = y;
        newPos.z = z;
        this.gameObject.transform.position = newPos;
    }

    //Two different decision trees determinant on color of piece, because pawns only move in one direction. Returns true if the move is valid.
            public bool ValidMove(Piece[,] parrBoard, Position pposMoveTo) {
            if (isWhite) {
                CheckEnPassant(parrBoard, pposMoveTo);

                if ((pposMoveTo.getX() == (position.getX() - 1) &&
                    pposMoveTo.getY() == position.getY() - 1) &&
                    ((parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                    IsEnemy(parrBoard, pposMoveTo)) ||
                    strEnPassant == "left")) {

                    return true;
                } else if ((pposMoveTo.getX() == (position.getX() + 1) &&
                      pposMoveTo.getY() == position.getY() - 1) &&
                      ((parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                      IsEnemy(parrBoard, pposMoveTo)) ||
                      strEnPassant == "right")) {

                    return true;
                }

                if (CheckSpace(parrBoard, pposMoveTo)) {
                    return true;
                }
            } else {
                CheckEnPassant(parrBoard, pposMoveTo);

                if ((pposMoveTo.getX() == (position.getX() - 1) &&
                    pposMoveTo.getY() == position.getY() + 1) &&
                    ((parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                    IsEnemy(parrBoard, pposMoveTo)) ||
                    strEnPassant == "left")) {

                    return true;
                } else if ((pposMoveTo.getX() == (position.getX() + 1) &&
                      pposMoveTo.getY() == position.getY() + 1) &&
                      ((parrBoard[pposMoveTo.getX(), pposMoveTo.getY()] != null &&
                      IsEnemy(parrBoard, pposMoveTo)) ||
                      strEnPassant == "right")) {

                    return true;
                }

                if (CheckSpace(parrBoard, pposMoveTo)) {
                    return true;
                }
            }
            return false;
        }

    //Checks if en passant is a valid move to the left or right
    private void CheckEnPassant(Piece[,] parrBoard, Position pposMoveTo)
    {
       // Pawn castPawnLeft = null;
       // Pawn castPawnRight = null;
       // if (position.getX() - 1 >= 0 &&
       //     parrBoard[position.getX() - 1, position.getY()] != null &&
       //     parrBoard[position.getX() - 1, position.getY()].PieceType() == "P" &&
       //     parrBoard[position.getX() - 1, position.getY()].IsWhite() != parrBoard[position.getX(), position.getY()].IsWhite())
       // {
       //     castPawnLeft = (Pawn)parrBoard[position.getX() - 1, position.getY()];
       // }
       // if ((position.getX() + 1) < 8 &&
       //     parrBoard[position.getX() + 1, position.getY()] != null &&
       //     parrBoard[position.getX() + 1, position.getY()].PieceType() == "P" &&
       //     parrBoard[position.getX() + 1, position.getY()].IsWhite() != parrBoard[position.getX(), position.getY()].IsWhite())
       // {
       //     castPawnRight = (Pawn)parrBoard[position.getX() + 1, position.getY()];
       // }
       // if (castPawnLeft == null && castPawnRight == null) return;

       // Position posEnPassantLeft = new Position(position.getX() - 1, position.getY());
       //Position posEnPassantRight = new Position(position.getX() + 1, position.getY());

       // if (castPawnLeft != null &&
       //     pposMoveTo.getX() == (position.getX() - 1) &&
       //           parrBoard[posEnPassantLeft.getX(), posEnPassantLeft.getY()] != null &&
       //           castPawnLeft.blnMoveTwo &&
       //           IsEnemy(parrBoard, posEnPassantLeft))
       // {
       //     strEnPassant = "left";

       // }
       // else if (castPawnRight != null &&
       //   pposMoveTo.getX() == (position.getX() + 1) &&
       //     parrBoard[posEnPassantRight.getX(), posEnPassantRight.getY()] != null &&
       //     castPawnRight.blnMoveTwo &&
       //     IsEnemy(parrBoard, posEnPassantRight))
       // {
       //     strEnPassant = "right";

       // }
    }
    //Checks if the space in front of the pawn is empty. Returns true if the space is empty.
    private bool CheckSpace(Piece[,] parrBoard, Position pposPosition)
    {
        if (isWhite)
        {
            if (pposPosition.getX() == position.getX() &&
                pposPosition.getY() < position.getY() &&
                Math.Abs(pposPosition.getY() - position.getY()) < 2 &&
                parrBoard[position.getX(), position.getY() - 1] == null)
            {

                return true;

            }
            else if (pposPosition.getX() == position.getX() &&
              pposPosition.getY() < position.getY() &&
              !hasMoved &&
              Math.Abs(pposPosition.getY() - position.getY()) < 3 &&
              parrBoard[position.getX(), position.getY() - 1] == null &&
              parrBoard[position.getX(), position.getY() - 2] == null)
            {

                return true;

            }
        }
        else
        {
            if (pposPosition.getX() == position.getX() &&
                pposPosition.getY() > position.getY() &&
                Math.Abs(pposPosition.getY() - position.getY()) < 2 &&
                parrBoard[position.getX(), position.getY() + 1] == null)
            {

                return true;

            }
            else if (pposPosition.getX() == position.getX() &&
                pposPosition.getY() > position.getY() &&
                !hasMoved &&
                Math.Abs(pposPosition.getY() - position.getY()) < 3 &&
                parrBoard[position.getX(), position.getY() + 1] == null &&
                parrBoard[position.getX(), position.getY() + 2] == null)
            {

                return true;

            }
        }

        return false;
    }

    //Determines if board space contains an enemy piece.
    private bool IsEnemy(Piece[,] parrBoard, Position pposPosition)
    {
        if (parrBoard[pposPosition.getX(), pposPosition.getY()].IsWhite() && isWhite)
        {
            return false;
        }
        else if (!parrBoard[pposPosition.getX(), pposPosition.getY()].IsWhite() && !isWhite)
        {
            return false;
        }
        return true;
    }

private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Tile")
        {
            // if Collided need to retrieve the collider's x,y,z coordinates
            this.x = collider.transform.position.x;
            this.y = collider.transform.position.y;
            this.z = collider.transform.position.z;
           int boardX = collider.GetComponent<Tile>().getBoardX();
           int boardY = collider.GetComponent<Tile>().getBoardY();
            Component comp = collider.GetComponent("Tile");
            Tile tl = collider.GetComponent<Tile>();
            Debug.Log("TL!: " + tl);
            Debug.Log("COMP: " + comp);
            //tempTile = collider.gameObject.GetComponent("Tile").getTile();

            //tempTile = collider.GetComponent<Tile>().getThisTile();
            //Debug.Log("TempTile X: "  + boardX + " TempTile Y: " + boardY);
            //Debug.Log("TempTile X: " + collider.GetComponent<Tile>().getBoardX() + " TempTile Y: " + GetComponent<Tile>().getBoardY());
            //Debug.Log("TempTile X: " + tempTile.getBoardX() + " TempTile Y: " + tempTile.getBoardY());
            //collider.GetComponent<Tile>().getBoardX();
            //collider.GetComponent<Tile>().getBoardY();
            //Debug.Log("World X: " + collider.transform.position.x + "   WORLD Y: " + collider.transform.position.y + "    WOLRD Z: " + collider.transform.position.z);
            //Vector3 newPos = this.transform.position;
            //newPos.x = collider.transform.position.x;
            //newPos.y = collider.transform.position.y;
            //newPos.z = collider.transform.position.z;
            //this.gameObject.transform.position = newPos;

            ////objCollider = collider.gameObject;
            //gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Exiting the collision");
        Vector3 newPos = this.transform.position;
        GameObject temp = GameObject.Find("Controller");
        newPos.x = temp.transform.position.x;
        newPos.y = temp.transform.position.y;
        newPos.z = temp.transform.position.z;
        this.gameObject.transform.position = newPos;

    }
}
