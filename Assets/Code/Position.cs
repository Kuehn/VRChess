using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Position Object. Holds x and y coordinates relating to the board.
/// </summary>
public class Position {
    private int x;
    private int y;

    //Constructor
    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    //Returns the x coordinate
    public int getX() {
        return x;
    }

    //Returns the y coordinate
    public int getY() {
        return y;
    }

    //Sets the x coordinate if it exists on the board.
    public void setX(int x) {
        if (x >= 0 && x < 8) {
            this.x = x;
        }
    }

    //Sets the y coordinate if it exists on the board.
    public void setY(int y) {
        if (x >= 0 && x < 8) {
            this.y = y;
        }
    }
}
