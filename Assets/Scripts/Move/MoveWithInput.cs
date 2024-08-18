using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithInput : MonoBehaviour, IMove
{
   
    [SerializeField]
    private Rigidbody sphereRB;

    private float moveInput;

    [SerializeField]
    private float acceleration;

    [SerializeField]
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sphereRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        transform.position = sphereRB.transform.position;
        
    }


  

    private void Acceleration(Transform transform)
    {
        // moveInput range (-1, 1)
        // transform.foward is z axis
        // acceleration
        sphereRB.velocity = Vector3.Lerp(sphereRB.velocity, moveInput * maxSpeed * transform.forward, Time.fixedDeltaTime * acceleration);
        // a + (b - a)t
        // a = sphere.velocity (vector3)
        // b = moveInput * maxSpeed * transform.forward (vector3)
        // t = Time.fixedDeltaTime * acceleration
    }

    public void Move()
    {
        Acceleration(transform);
    }
}
