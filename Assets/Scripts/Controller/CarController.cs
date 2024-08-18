using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    IMoveWithDestination carMove;
    IRotateWithDestination carRotate;
    WayPointTraffic wayPointTraffic;

    private void Awake()
    {
       
        
    }
    // Start is called before the first frame update
    void Start()
    {
        wayPointTraffic = GetComponent<WayPointTraffic>();
        if (wayPointTraffic == null)
        {
            Debug.LogError("WayPointTraffic component is missing.");
        }

        carMove = GetComponent<IMoveWithDestination>();
        if (carMove == null)
        {
            Debug.LogError("IMove component is missing.");
        }

        carRotate = GetComponent<IRotateWithDestination>();
        if (carRotate == null)
        {
            Debug.LogError("IRotate component is missing.");
        }

        if (wayPointTraffic != null && carMove != null && carRotate != null)
        {
            StartCoroutine(DelayInitilize(1f));
        }
    }

    IEnumerator DelayInitilize(float timer)
    {
        yield return new WaitForSeconds(timer);
        InitializeCarAnimation();
    }
    private void InitializeCarAnimation()
    {
        Move();
        Rotate();
    }

    private void Move()
    {     
        carMove.Move(base.gameObject.transform, wayPointTraffic.currentPointTransform);
    }

    private void Rotate()
    {      
        carRotate.Rotate(transform, wayPointTraffic.currentPointTransform);
    }

    public void OnReachWayPoint()
    {
        wayPointTraffic.MoveToNextWaypoint();
        InitializeCarAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
