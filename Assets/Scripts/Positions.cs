using System;
using UnityEngine;

public static class Vector3Positions
{
    public static Vector3 Up = new Vector3(0, 10, 0);
    public static Vector3 Down = new Vector3(0, 0, 0);
    public static Vector3 Left = new Vector3(-5, 5, 0);
    public static Vector3 Right = new Vector3(5, 5, 0);

    public static Vector3 GetRelativePosition(Positions position)
    {
        switch (position)
        {
            case Positions.Down:
                return Down;
            case Positions.Up:
                return Up;
            case Positions.Left:
                return Left;
            case Positions.Right:
                return Right;
            default:
                throw new ArgumentOutOfRangeException("position", position, null);
        }
    }
}

public enum Positions
{
    Up,
    Down,
    Left,
    Right,
}