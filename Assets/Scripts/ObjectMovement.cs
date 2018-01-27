using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement
{
    private int _zspeed;
    private int _yspeed;
    private int _xspeed;
    private Vector3 _currentPos;

    public ObjectMovement(int xspeed, int yspeed, int zspeed, Vector3 startPosition)
    {
        _zspeed = zspeed;
        _xspeed = xspeed;
        _yspeed = yspeed;
        _currentPos = startPosition;
    }

    public Vector3 GetUpdatedPosition(float timePassed)
    {
        var z = _currentPos.z + _zspeed * timePassed;
        var y = _currentPos.y + _yspeed * timePassed;
        var x = _currentPos.x + _xspeed * timePassed;

        var movement = new Vector3(x, y, z);
        _currentPos = movement;
        return _currentPos;
    }
}
