using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Position Object. Holds x and y coordinates relating to the board.
/// </summary>
public class Position : MonoBehaviour
{
    private int x;
    private int y;
    private float worldX;
    private float worldY;
    private float worldZ;
    private Vector3 worldPosition;
    private Tile tile;

    //public static Object prefab = Resources.Load("Prefabs/Tile");
    
    //public static Position Create(int x, int y, float worldX, float worldY, float worldZ)
    //{
    //    GameObject newObject = Instantiate(prefab) as GameObject;
    //    Position tile = newObject.GetComponent<Position>();
    //    return tile;
    //}

    //Constructor
    public Position(int x, int y, Tile tile)
    {
        this.x = x;
        this.y = y;
        this.tile = tile;
        //this.worldX = worldX;
        //this.worldY = worldY;
        //this.worldZ = worldZ;

    }

    //Returns the x coordinate
    public int getX()
    {
        return x;
    }

    //Returns the y coordinate
    public int getY()
    {
        return y;
    }

    //Returnds the worldX coordinate
    public float getWorldX()
    {
        return this.worldX;
    }
    //Returnds the worldY coordinate
    public float getWorldY()
    {
        return this.worldY;
    }
    //Returnds the worldZ coordinate
    public float getWorldZ()
    {
        return this.worldZ;
    }
 
    public Tile getTile()
    {
        return this.tile;
    }

    public Vector3 getWorldPostion()
    {
        return worldPosition;
    }
    //Sets the x coordinate if it exists on the board.
    public void setX(int x)
    {
        if (x >= 0 && x < 8)
        {
            this.x = x;
        }
    }

    //Sets the y coordinate if it exists on the board.
    public void setY(int y)
    {
        if (x >= 0 && x < 8)
        {
            this.y = y;
        }
    }
    public void setWorldX(float worldX)
    {
        this.worldX = worldX;
    }
    public void setWorldY(float worldY)
    {
        this.worldY = worldY;
    }
    public void setWorldZ(float worldZ)
    {
        this.worldZ = worldZ;
    }
    public void setWorldPos(Vector3 pos)
    {
        this.worldPosition = pos;
    }


}
