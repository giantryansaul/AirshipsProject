using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class ObjectMovementTest {

    [Test]
    public void UpdatePositionTest()
    {
        var enemy = new ObjectMovement(0, 0, 1, new Vector3(1, 1, 1));
        const float timePassed = 2.0f;
        var newPosition = enemy.GetUpdatedPosition(timePassed);

        Assert.AreEqual(1, newPosition.x);
        Assert.AreEqual(1, newPosition.y);
        Assert.AreEqual(3, newPosition.z);

        newPosition = enemy.GetUpdatedPosition(timePassed);
        
        Assert.AreEqual(5, newPosition.z);
    }
}
