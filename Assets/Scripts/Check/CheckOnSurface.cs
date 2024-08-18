using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckOnSurface : MonoBehaviour
{

    [SerializeField]
    Rigidbody sphereRB;

    [SerializeField]
    private LayerMask derivaleSurface;

    RaycastHit hit;

    private float rayLength;

    public UnityEvent actionEventOn;
    public UnityEvent actionEventOff;
    

    

    private void Start()
    {
        sphereRB.transform.parent = null;
        this.rayLength = sphereRB.GetComponent<SphereCollider>().radius + 0.2f;
    }

    private void Update()
    {
        isRightSuface();
    }


    public void isRightSuface()
    {
        if (Physics.Raycast(sphereRB.transform.position, Vector3.down, out hit, rayLength, derivaleSurface))
        {
            actionEventOn.Invoke();
        } else
        {
            actionEventOff.Invoke();
        }
    }
}
