using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class TiltModel : MonoBehaviour, ITiltModel
{
    RaycastHit hit;

    [SerializeField]
    Rigidbody rb;


    [SerializeField]
    float tileIncrement = .09f, zTiltAngle = 45f, maxSpeedTilt;



    float currentVelocityOffset, steerInput;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");
        Tilt();
    }

    void CacurlateCurrentVelocityOffSet(Rigidbody rb)
    {
        velocity = rb.transform.InverseTransformDirection(rb.velocity);
        currentVelocityOffset = velocity.z / maxSpeedTilt;
    }

  

    public void Tilt()
    {
        CacurlateCurrentVelocityOffSet(rb);
        if (velocity != null)
        {
            float xRot = (Quaternion.FromToRotation(rb.transform.up, hit.normal) * rb.transform.rotation).eulerAngles.x;
            float zRot = 0;

            if (currentVelocityOffset > 0)
            {
                zRot = -zTiltAngle * steerInput * currentVelocityOffset;
            }



            Quaternion targetRot = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(xRot, transform.eulerAngles.y, zRot), tileIncrement);

            Quaternion newRotation = Quaternion.Euler(targetRot.eulerAngles.x, transform.eulerAngles.y, targetRot.eulerAngles.z);

            

            rb.MoveRotation(newRotation);
        }
        else
        {
            Debug.LogError("Null reference aception");
        }

    }
}
