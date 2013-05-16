using System;

public class Direction
{
    public int[] dirX
    {
        get
        {
            return this.dirX;
        }
        set
        {
            this.dirX = new int[8] { 1, 1, 1, 0, -1, -1, -1, 0 };
        }
    }

    public int[] dirY
    {
        get
        {
            return this.dirY;
        }
        set
        {
            this.dirY = new int[8] { 1, 0, -1, -1, -1, 0, 1, 1 };
        }
    }
}