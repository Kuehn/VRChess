using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

    private Piece[,] arrBoard;
    private Piece[] arrWhites;
    private Piece[] arrBlacks;
    private bool blnWhiteTurn;
    private bool blnCheckmate;

    public Vector2 boardSize = new Vector2(0, 0);
    public GameObject tilePrefab;
    public Pawn pawnPrefab;


    // Use this for initialization
    void Start() {
        arrBoard = new Piece[8, 8];
        arrWhites = new Piece[16];
        arrBlacks = new Piece[16];
        blnWhiteTurn = true;
        blnCheckmate = false;

        SetBoard();
    }

    // Update is called once per frame
    void Update() {

    }

    //public Piece SelectPiece(Position pposPosition)
    //{
    //    if(arrBoard[pposPosition.getX(), pposPosition.getY()] != null)
    //    {
    //        arrBoard[pposPosition.getX(), pposPosition.getY()].SetSelected(true);
    //        PrintBoard();
    //        //return arrBoard[pintPosition.getX(), pintPosition.getY()];
    //    }

    //    return null;
    //}

    //Moves a given piece from one space to another if the move is valid. Returns true if a move was made.
    public bool SetPiece(Position pposPosition, Position pposMoveto) {
        if (arrBoard[pposPosition.getX(), pposPosition.getY()].ValidMove(arrBoard, pposMoveto)) {
            arrBoard[pposMoveto.getX(), pposMoveto.getY()] = null;
            arrBoard[pposPosition.getX(), pposPosition.getY()].SetPosition(pposMoveto);
            arrBoard[pposMoveto.getX(), pposMoveto.getY()] = arrBoard[pposPosition.getX(), pposPosition.getY()];
            arrBoard[pposPosition.getX(), pposPosition.getY()] = null;
            return true;
        }
        return false;
    }

    //Sets the initial state of the board.
    private void SetBoard() {
        //inital white piece positions
        //Tile bla = Tile.Create();
        GameObject board = new GameObject();
        // board.name = "Board";
        //Tile[] posBoard = new Tile[(int)boardSize.x * (int)boardSize.y];
        Tile[,] tileOnBoard = new Tile[8,8];
        int pos = 0;
        for (int x = 0; x < boardSize.x; x++)
        {
            for (int y = 0; y < boardSize.y; y++)
            {
                Vector3 worldPosition = new Vector3( 0.5f + (x * .125f), 1f, + 0.5f + (y *.125f)); //the .09 and .125 are the tile object size, I should change the code to retrieve the object scale size when i get there.
                GameObject newTile = Instantiate(tilePrefab, worldPosition, Quaternion.Euler(Vector3.right)) as GameObject;
                //newTile.GetComponent<Renderer>().material.color = Color.black;
                tileOnBoard[x,y] = new Tile(worldPosition.x, worldPosition.y, worldPosition.z, x, y);
                //posBoard[pos] = new Tile(worldPosition.x, worldPosition.y, worldPosition.z,x,y);
                //pos++;
            }
        }

        Debug.Log("POSWHITE LENGTH: " + tileOnBoard.Length);
        Position posWhitePawn1 = new Position(0, 6, tileOnBoard[0,6]);
        Position posWhitePawn2 = new Position(1, 6, tileOnBoard[1,6]);
        Position posWhitePawn3 = new Position(2, 6, tileOnBoard[2,6]);
        Position posWhitePawn4 = new Position(3, 6, tileOnBoard[3,6]);
        Position posWhitePawn5 = new Position(4, 6, tileOnBoard[4,6]);
        Position posWhitePawn6 = new Position(5, 6, tileOnBoard[5,6]);
        Position posWhitePawn7 = new Position(6, 6, tileOnBoard[6,6]);
        Position posWhitePawn8 = new Position(7, 6, tileOnBoard[7,6]);


        Debug.Log("PosWHITE1 Pos: " + posWhitePawn1.getTile().getWorldPosition());
        Debug.Log("PosWHITE2 Pos: " + posWhitePawn2.getTile().getWorldPosition());
        Debug.Log("PosWHITE3 Pos: " + posWhitePawn3.getTile().getWorldPosition());
        Debug.Log("PosWHITE4 Pos: " + posWhitePawn4.getTile().getWorldPosition());
        Debug.Log("PosWHITE5 Pos: " + posWhitePawn5.getTile().getWorldPosition());
        Debug.Log("PosWHITE6 Pos: " + posWhitePawn6.getTile().getWorldPosition());
        Debug.Log("PosWHITE7 Pos: " + posWhitePawn7.getTile().getWorldPosition());
        Debug.Log("PosWHITE8 Pos: " + posWhitePawn8.getTile().getWorldPosition());

        //inital black piece positions
        Position posBlackPawn1 = new Position(0, 1, tileOnBoard[0,1]);
        Position posBlackPawn2 = new Position(1, 1, tileOnBoard[1,1]);
        Position posBlackPawn3 = new Position(2, 1, tileOnBoard[2,1]);
        Position posBlackPawn4 = new Position(3, 1, tileOnBoard[3,1]);
        Position posBlackPawn5 = new Position(4, 1, tileOnBoard[4,1]);
        Position posBlackPawn6 = new Position(5, 1, tileOnBoard[5,1]);
        Position posBlackPawn7 = new Position(6, 1, tileOnBoard[6,1]);
        Position posBlackPawn8 = new Position(7, 1, tileOnBoard[7,1]);

        //white pieces
        Pawn pwnWhite1 = Instantiate(pawnPrefab, posWhitePawn1.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite2 = Instantiate(pawnPrefab, posWhitePawn2.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite3 = Instantiate(pawnPrefab, posWhitePawn3.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite4 = Instantiate(pawnPrefab, posWhitePawn4.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite5 = Instantiate(pawnPrefab, posWhitePawn5.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite6 = Instantiate(pawnPrefab, posWhitePawn6.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite7 = Instantiate(pawnPrefab, posWhitePawn7.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnWhite8 = Instantiate(pawnPrefab, posWhitePawn8.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        
        //Debug.Log("")

        pwnWhite1.setWhite(true);
        pwnWhite2.setWhite(true);
        pwnWhite3.setWhite(true);
        pwnWhite4.setWhite(true);
        pwnWhite5.setWhite(true);
        pwnWhite6.setWhite(true);
        pwnWhite7.setWhite(true);
        pwnWhite8.setWhite(true);


        //black pieces
        Pawn pwnBlack1 = Instantiate(pawnPrefab, posBlackPawn1.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack2 = Instantiate(pawnPrefab, posBlackPawn2.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack3 = Instantiate(pawnPrefab, posBlackPawn3.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack4 = Instantiate(pawnPrefab, posBlackPawn4.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack5 = Instantiate(pawnPrefab, posBlackPawn5.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack6 = Instantiate(pawnPrefab, posBlackPawn6.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack7 = Instantiate(pawnPrefab, posBlackPawn7.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;
        Pawn pwnBlack8 = Instantiate(pawnPrefab, posBlackPawn8.getTile().getWorldPosition(), Quaternion.Euler(Vector3.right)) as Pawn;

        pwnBlack1.setWhite(false);
        pwnBlack2.setWhite(false);
        pwnBlack3.setWhite(false);
        pwnBlack4.setWhite(false);
        pwnBlack5.setWhite(false);
        pwnBlack6.setWhite(false);
        pwnBlack7.setWhite(false);
        pwnBlack8.setWhite(false);

        //set white pieces on board
        arrBoard[posWhitePawn1.getTile().getBoardX(), posWhitePawn1.getTile().getBoardY()] = pwnWhite1;
        arrBoard[posWhitePawn2.getTile().getBoardX(), posWhitePawn2.getTile().getBoardY()] = pwnWhite2;
        arrBoard[posWhitePawn3.getTile().getBoardX(), posWhitePawn3.getTile().getBoardY()] = pwnWhite3;
        arrBoard[posWhitePawn4.getTile().getBoardX(), posWhitePawn4.getTile().getBoardY()] = pwnWhite4;
        arrBoard[posWhitePawn5.getTile().getBoardX(), posWhitePawn5.getTile().getBoardY()] = pwnWhite5;
        arrBoard[posWhitePawn6.getTile().getBoardX(), posWhitePawn6.getTile().getBoardY()] = pwnWhite6;
        arrBoard[posWhitePawn7.getTile().getBoardX(), posWhitePawn7.getTile().getBoardY()] = pwnWhite7;
        arrBoard[posWhitePawn8.getTile().getBoardX(), posWhitePawn8.getTile().getBoardY()] = pwnWhite8;

        //set black pieces on board
        arrBoard[posBlackPawn1.getX(), posBlackPawn1.getY()] = pwnBlack1;
        arrBoard[posBlackPawn2.getX(), posBlackPawn2.getY()] = pwnBlack2;
        arrBoard[posBlackPawn3.getX(), posBlackPawn3.getY()] = pwnBlack3;
        arrBoard[posBlackPawn4.getX(), posBlackPawn4.getY()] = pwnBlack4;
        arrBoard[posBlackPawn5.getX(), posBlackPawn5.getY()] = pwnBlack5;
        arrBoard[posBlackPawn6.getX(), posBlackPawn6.getY()] = pwnBlack6;
        arrBoard[posBlackPawn7.getX(), posBlackPawn7.getY()] = pwnBlack7;
        arrBoard[posBlackPawn8.getX(), posBlackPawn8.getY()] = pwnBlack8;
    }
    public bool GetWhiteTurn()
    {
        return blnWhiteTurn;
    }

    public Piece[,] getBoard()
    {
        return this.arrBoard;
    }
}
