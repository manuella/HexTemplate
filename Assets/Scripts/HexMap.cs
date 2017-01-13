using UnityEngine;
using System.Collections;
using System;

// As described here http://www.redblobgames.com/grids/hexagons/
// Implmenting both axial and cubic
// Pointy top
//


public class HexMap {
    int[,,] axialCoordGrid;
    int[,,,] cubeCoord;

    


}

public class Hex{

    private int _q;
    private int _r;

    private int _x;
    private int _y;
    private int _z;

    public int q { get { return _q; } }
    public int r { get { return _r; } }

    public int x { get { return _x; } }
    public int y { get { return _y; } }
    public int z { get { return _z; } }


    public Hex(int xIn, int yIn, int zIn = Int32.MaxValue)
    {
        // if we're received axial
        if (zIn == Int32.MaxValue)
        {
            _q = xIn;
            _r = yIn;

            ConvertAxialToCubic();
        }
        else
        {
            _x = xIn;
            _y = yIn;
            _z = zIn;

            ConvertCubicToAxial();
        }

    }

    private void ConvertAxialToCubic()
    {
        _x = _q;
        _z = _r;
        _y = -(_x) - (_z);
    }

    private void ConvertCubicToAxial()
    {
        _q = _x;
        _r = _z;
    }


}
