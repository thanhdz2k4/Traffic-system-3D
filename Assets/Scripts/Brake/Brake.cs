using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [Range(1, 10)]
    private float brakingFactor;

    private void Update()
    {
        _Brake();
    }

    void _Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity *= brakingFactor / 10;
        }
    }

}
