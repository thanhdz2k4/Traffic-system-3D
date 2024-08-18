using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class MoveToTheDestination : MonoBehaviour, IMoveWithDestination
{
    [SerializeField]
    private float durationMove;

    public UnityEvent TriggerOnReachWayPoin;

    Tween tween;
    private bool isStop;


    private float timer = 0;
    private float timerDelay = 2f;

    private void OnReachWaypoint()
    {
        TriggerOnReachWayPoin?.Invoke();
    }


    public void StopMove()
    {
        tween.Pause();
        isStop = true;
    }

    public void StopMoveInSmartRoad()
    {
        tween.Pause();
    }

    private void Update()
    {
        if(isStop)
        {
            timer += Time.deltaTime;
            if (timer >= timerDelay)
            {
                tween.Play();
                isStop = false;
                timer = 0;

            }
        }
        
    }


    public void ContinueMove()
    {
        tween.Play();
    }

    public void Move(Transform transform, Transform destination)
    {
        tween = transform.DOMove(destination.position, durationMove).OnComplete(OnReachWaypoint).SetEase(Ease.Linear);
    }

 
}
