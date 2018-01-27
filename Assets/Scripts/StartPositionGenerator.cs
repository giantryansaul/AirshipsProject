using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionGenerator
{
    public static int StartZ = 40;
    public static int StartY = 0;
    public static int StartXRange = 10;
    public static int Seed = 1001;
    
    public static Vector3 GenerateFloatingEnemyStartPosition()
    {
        Random.InitState(Seed);
        var xPosition = Random.Range(-StartXRange, StartXRange);
        var startPosition = new Vector3(xPosition, StartY, StartZ);
        return startPosition;
    }
}
