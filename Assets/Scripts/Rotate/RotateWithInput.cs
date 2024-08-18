using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithInput : MonoBehaviour, IRotate
{
    private float steerInput, moveInput;
    [SerializeField]
    private float steerStrength;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        Rotate();
    }


    public void Rotate()
    {
        transform.Rotate(0, steerInput * moveInput * steerStrength * Time.deltaTime, 0, Space.World);
    }
}
