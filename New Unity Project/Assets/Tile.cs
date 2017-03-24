using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private GameObject objCollider;
    private float worldX;
    private float worldY;
    private float worldZ;
    private int boardX;//Position in array
    private int boardY; 
    private Vector3 worldPosition;
    //public Material[] material;
    //Renderer rnd;
    //public static Object prefab = Resources.Load("Prefabs/Tile");
    //public static Tile Create()
    //{
    //   GameObject newObject = Instantiate(prefab) as GameObject;
    //   Tile tile = newObject.GetComponent<Tile>();
    //    //tile.rnd = tile.GetComponent<Renderer>();
    //    //tile.rnd.sharedMaterial = tile.material[0];
    //    return tile;
    //}

    public Tile(float worldX, float worldY, float worldZ, int boardX, int boardY)
    {
        this.worldX = worldX;
        this.worldY = worldY;
        this.worldZ = worldZ;
        this.boardX = boardX;
        this.boardY = boardY;
        
        setWorldPosition(worldX, worldY, worldZ);
    }
    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    void Update()
    {

    }

    public Tile getThisTile() 
    {
        Debug.Log("TTTile X: "  + boardX + " TempTile Y: " + boardY + " worldX: " + worldX);
        return this; //Never returned just this before but it makes sense.
    }

    public int getBoardX()
    {
        return this.boardX;
    }
    public int getBoardY()
    {
        return this.boardY;
    }
    public float getWorldX()
    {
        return worldX;
    }
    public float getWorldY()
    {
        return worldY;
    }
    public float getWorldZ()
    {
        return worldZ;
    }

    public Vector3 getWorldPosition()
    {
        return worldPosition;
    }

    void setWorldX(float worldX)
    {
        this.worldX = worldX;
    }
    void setWorldY(float worldY)
    {
        this.worldY = worldY;
    }
    void setWorldZ(float worldZ)
    {
        this.worldZ = worldZ;
    }

    private void setWorldPosition(float x, float y, float z)
    {
        worldPosition = new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider collider)
    {
       // Debug.Log("World X: " + worldX + "   WORLD Y: " + worldY);
        //objCollider = collider.gameObject;
        //gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
