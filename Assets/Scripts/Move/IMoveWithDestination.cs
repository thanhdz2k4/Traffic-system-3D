using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveWithDestination 
{
    void Move(Transform transform, Transform destination);
}
