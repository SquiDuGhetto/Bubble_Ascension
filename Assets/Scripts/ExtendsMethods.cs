using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendsMethods
{
    public static float VectorToAngle(this Vector3 v1, Vector3 v2)
    {
        return Vector3.Angle(v1, v2);
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static float Abs(this float f)
    {
        return Mathf.Abs(f);
    }
}
