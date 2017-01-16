using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

// As described here http://www.redblobgames.com/grids/hexagons/
// Implmenting both axial and cubic
// Pointy top
//

// Pointy top means no north / south
public enum Direction {NORTHEAST, EAST, SOUTHEAST, SOUTHWEST,
                          WEST, NORTHWEST};

public class HexMap
{
    Hex[,] axialCoordGrid;
    Hex[,,] cubeCoord;

    public void LinearPathFromTo(Coordinate start, Coordinate destination)
    {
        throw new NotImplementedException();
    }

    public void LinearPathWithObsticals(Coordinate start, Coordinate destination)
    {
        throw new NotImplementedException();
    }

    public HexMap()
    {

    }


    public int Distance(Coordinate startCoord, Coordinate destinationCoord)
    {
        int[] start = startCoord.GetCubic();
        int[] destination = destinationCoord.GetCubic();

        return (Math.Abs(start[0] - destination[0]) + Math.Abs(start[1] - destination[1]) +
                Math.Abs(start[2] - destination[2]));
    }
    /*
    public Coordinate[] LinearPath(Coordinate start, Coordinate end, float t, int i)
    {
        Vector3 startVector = start.ConvertToVector3();
        Vector3 endVector = end.ConvertToVector3();

        Vector3 cube = new Vector3(FloatLerp(startVector.x, endVector.x, t),
                                   FloatLerp(startVector.y, endVector.y, t),
                                   FloatLerp(startVector.z, endVector.z, t));

        float distance = this.Distance(start, end);

        List<Hex> path = new List<Hex>();

        for(int j = 0; j<i; j++)
        {
            path.Add()
        }
    }*/



    private int [] CubeRound(Vector3 point, float accuracy)
    {
        int [] roundedPoint  = new int[]{ (int)Math.Round(point.x),
                                           (int)Math.Round(point.y),
                                           (int)Math.Round(point.z)};

        Vector3 diffPoint  = new Vector3((roundedPoint[0] - point.x),
                                         (roundedPoint[1] - point.y),
                                         (roundedPoint[2] - point.z));

        if ((diffPoint.x > diffPoint.y) && (diffPoint.x > diffPoint.z))
        {
            diffPoint.x = diffPoint.y - diffPoint.z;
        }
        else if (diffPoint.y > diffPoint.z)
        {
            diffPoint.y = diffPoint.x - diffPoint.z;
        }
        else
        {
            diffPoint.z = -diffPoint.x - diffPoint.y;
        }
        return new int[] { (int)diffPoint.x, (int)diffPoint.y, (int)diffPoint.z};
    }

    public Hex [] PathFind(Coordinate start, Coordinate end)
    {
        throw new NotImplementedException();
    }



    private float FloatLerp(float x, float y, float t)
    {
        return x + (y - x) * t;
    }


}


public class Coordinate
{
    public int q;
    public int r;

    public int x;
    public int y;
    public int z;

    public Coordinate(int _x = Int32.MaxValue, int _y = Int32.MaxValue, int _z = Int32.MaxValue)
    {
        // fill axial then cubic
        if (_z == Int32.MaxValue)
        {
            q = _x;
            r = _y;
            ConvertAxialToCubic();
        }
        else
        {
            x = _x;
            y = _y;
            z = _z;
            ConvertCubicToAxial();
        }
    }

    public Coordinate[] Neighbors()
    {
        return new Coordinate[] { new Coordinate(x+1, y-1, z),
                                  new Coordinate(x-1, y+1, z),
                                  new Coordinate(x-1, y, z+1),
                                  new Coordinate(x+1, y, z-1),
                                  new Coordinate(x, y-1, z+1),
                                  new Coordinate(x, y+1, z-1)};
    }

    public Coordinate GetHexDirection(Direction direction)
    {
        Coordinate coord = null;
        switch (direction)
        {

            case Direction.NORTHEAST:
                coord = new Coordinate(x + 1, y, z - 1);
                break;

            case Direction.EAST:
                coord = new Coordinate(x + 1, y -1, z);
                break;

            case Direction.SOUTHEAST:
                coord = new Coordinate(x, y - 1, z + 1);
                break;

            case Direction.SOUTHWEST:
                coord = new Coordinate(x - 1, y, z + 1);
                break;

            case Direction.WEST:
                coord = new Coordinate(x - 1, y + 1, z);
                break;

            case Direction.NORTHWEST:
                coord = new Coordinate(x, y + 1, z - 1);
                break;
        }
        if(coord == null)
        {
            throw new System.Exception();
        }
        return coord;
    }




    public int[] GetAxial() { return new int[] { q, r }; }
    public int[] GetCubic() { return new int[] { x, y, z }; }

    public Vector3 ConvertToVector3()
    {
        return new Vector3(x,y,z);
    }

    public Vector2 ConvertToVector2()
    {
        return new Vector2(q, r);
    }

    private void ConvertAxialToCubic()
    {
        x = q;
        y = r;
        z = (-q - r);
    }

    private void ConvertCubicToAxial()
    {
        q = x;
        r = z;
    }

}
public class Hex { }