using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotateWithDestination : MonoBehaviour, IRotateWithDestination
{

    [SerializeField]
    private float durationRotate = 2f;

    public void Rotate(Transform transform, Transform destination)
    {
        Quaternion targetRotation = Quaternion.LookRotation(destination.position - transform.position);

        Vector3 newRotation = new Vector3(transform.eulerAngles.x, targetRotation.eulerAngles.y, transform.eulerAngles.z);

        transform.DORotate(newRotation, durationRotate).SetEase(Ease.Linear);
    }

    
}
