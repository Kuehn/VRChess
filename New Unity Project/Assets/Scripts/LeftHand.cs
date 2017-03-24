using UnityEngine;
using System.Collections;

public class LeftHand : MonoBehaviour {

    private Valve.VR.EVRButtonId btnGrip = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId btnTrigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    //private GameObject objPickup;
    private Pawn objPickup;

    private Board objBoard;
    private Piece[,] boardPieces;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private bool moved = false;
    private bool CheckMate = false;
    // Use this for initialization 
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        objBoard = new Board();
        boardPieces = objBoard.getBoard();
    }
	
	// Update is called once per frame
	void Update () {
        //while (!CheckMate)
      //  {
            if (objBoard.GetWhiteTurn())
            {
               // Debug.Log("White select a piece.");
            }
            else
            {
              //  Debug.Log("Black select a piece.");
            }
        bool valid = false;
        bool passover = false;
        moved = false;
        Position selection = null;

        if (controller == null)
            {
                Debug.Log("Controller not initialized");
                return;
            }
            //Select Piece
            if (controller.GetPressDown(btnGrip) && objPickup != null)
            {
                objPickup.transform.parent = this.transform;
                objPickup.SetSelected(true);
                Debug.Log("BUTTON PRESSED DOWN");

            }
            //Set Piece
            if (controller.GetPressUp(btnGrip) && objPickup != null)
            {
               //Vector3 attemptPositionB =  objPickup.getPositionMovingTo(); //RECIEVE Array Position On Board
                //if objPickup.ValidMove()
                objPickup.MovePieceToTile();
                objPickup.transform.parent = null;
                objPickup.SetSelected(false);
            Debug.Log("BUTTON Released object");
            }

          // }
        }

  
   private void OnTriggerEnter(Collider collider)
    {
        objPickup= collider.gameObject.GetComponent<Pawn>();
        objPickup.GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnTriggerExit(Collider collider)
    {
        objPickup = null;
        objPickup.GetComponent<Rigidbody>().useGravity = false;

    }

}
