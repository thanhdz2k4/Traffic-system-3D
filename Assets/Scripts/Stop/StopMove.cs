using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopMove : MonoBehaviour
{
    [SerializeField]
    private float distanceMinimize;


    public UnityEvent OnStopMove = new UnityEvent();


    void Update()
    {
        Vector3 rayDirection2 = transform.forward;

        // Raycast 1
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), rayDirection2, out RaycastHit hit1, distanceMinimize))
        {
            if (hit1.collider.CompareTag("Car"))
            {
                OnStopMove?.Invoke();
                Debug.DrawLine(transform.position, hit1.point, Color.red);
                Debug.DrawRay(hit1.point, Vector3.up * 0.1f, Color.red);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + rayDirection2 * distanceMinimize, Color.green);
            }
        }
    }



}
