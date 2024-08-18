using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float gravity;

    public void _Gravity()
    {
        rb.AddForce(gravity * Vector3.down, ForceMode.Acceleration);
    }
}
