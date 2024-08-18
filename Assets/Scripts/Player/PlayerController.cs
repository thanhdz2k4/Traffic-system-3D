using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Gravity gravity;
    // Start is called before the first frame update
    void Start()
    {
        gravity = GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        gravity._Gravity();
    }
}
