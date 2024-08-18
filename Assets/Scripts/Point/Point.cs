using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField]
    List<Point> points;
    public Point GetRandomNextPoint()
    {
        return points[Random.Range(0, points.Count)];
    }
}
