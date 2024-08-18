using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointTraffic : MonoBehaviour
{
    [SerializeField]
    Point point;  
    public Transform currentPointTransform { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentPointTransform = point.transform;
    }

    public void MoveToNextWaypoint()
    {
        RandomNextPoint();
        SetCurrentPoint(point.transform);
    }


    private void RandomNextPoint()
    {
        point = point.GetRandomNextPoint();
    }

    private void SetCurrentPoint(Transform point)
    {
        this.currentPointTransform = point;
    }

        
}
