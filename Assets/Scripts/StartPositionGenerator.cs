using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomUnity = UnityEngine.Random;

public static class StartPositionGenerator
{
    public static int StartZ = 200;
    public static int Seed = 1001;

    static StartPositionGenerator()
    {
        RandomUnity.InitState(Seed);
    }

    public static Positions GenerateLanePosition()
    {
        var values = Enum.GetValues(typeof(Positions));
        var position = values.GetValue(RandomUnity.Range(0, values.Length));
        return (Positions) position;
    }
    
    public static Vector3 GenerateFloatingEnemyStartPosition(Positions position, Vector3 relativePosition)
    {
        return new Vector3(0, 0, StartZ) + relativePosition + Vector3Positions.GetVector3(position);
    }
}
