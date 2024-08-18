using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartRoad : MonoBehaviour
{
    [SerializeField]
    Queue<MoveToTheDestination> queueOfCar = new Queue<MoveToTheDestination>();

    [SerializeField]
    MoveToTheDestination currentCar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCar == null && queueOfCar.Count > 0)
        {
           
            currentCar = queueOfCar.Dequeue();
            currentCar.GetComponent<MoveToTheDestination>().ContinueMove();
            if(currentCar == null)
            {
                Debug.LogError("Null reference aception");
            }
            
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            var car = other.GetComponent<MoveToTheDestination>();
            if (car != null && car != currentCar)
            {
                queueOfCar.Enqueue(car);
                car.StopMoveInSmartRoad();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            var car = other.GetComponent<MoveToTheDestination>();
            RemoveCar(car);
        }
    }

    private void RemoveCar(MoveToTheDestination car)
    {
        if(car == currentCar)
        {
            currentCar = null;
        }
    }
}
