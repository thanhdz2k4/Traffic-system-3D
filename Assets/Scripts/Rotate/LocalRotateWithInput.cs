using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotateWithInput :MonoBehaviour, IRotate
{
    [SerializeField]
    private float handleRotVal = 30f, handleRotSpeed = .15f;
    private float steerInput;



    // Update is called once per frame
    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");
        Rotate();
    }

    public void Rotate()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.eulerAngles.x, handleRotVal * steerInput, transform.localRotation.eulerAngles.z), handleRotSpeed);
    }
}
