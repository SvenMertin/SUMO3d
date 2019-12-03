#if (UNITY_EDITOR) 
using UnityEngine;
using System;

public class InPolyChecker : MonoBehaviour
{

    public static bool IsPointInPolygon(float x, float y, Vector3[] polygon)
    {
        double minX = polygon[0].x;
        double maxX = polygon[0].x;
        double minY = polygon[0].z;
        double maxY = polygon[0].z;
        for (int i = 1; i < polygon.Length; i++)
        {
            minX = Math.Min(polygon[i].x, minX);
            maxX = Math.Max(polygon[i].x, maxX);
            minY = Math.Min(polygon[i].z, minY);
            maxY = Math.Max(polygon[i].z, maxY);
        }

        if (x < minX || x > maxX || y < minY || y > maxY)
        {
            return false;
        }

        bool inside = false;
        for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
        {
            if ((polygon[i].z > y) != (polygon[j].z > y) &&
                 x < (polygon[j].x - polygon[i].x) * (y - polygon[i].z) / (polygon[j].z - polygon[i].z) + polygon[i].x)
            {
                inside = !inside;
            }
        }

        return inside;


    }
}
#endif