using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyMath
{
    public static bool CloseOrPassed(Vector3 position, Vector3 direction, Vector3 goal)
    {
        if ((position - goal).magnitude < 0.05)
        {
            return true;
        }

        if ((position - goal).normalized == direction.normalized)
        {
            return true;
        }

        return false;
    }

    public static bool Close(Vector3 position, Vector3 goal)
    {
        if ((position - goal).magnitude < 0.05)
        {
            return true;
        }

        return false;
    }
}
