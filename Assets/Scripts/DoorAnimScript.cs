using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using UnityEngine;

public class DoorAnimScript : MonoBehaviour
{
    public GameObject animObject;
    public GameObject animObject2;
    private AudioSource DoorSound;
    [SerializeField]
    private AudioClip[] doorClips;

    
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    [SerializeField] private Vector3 startPoint2;
    [SerializeField] private Vector3 endPoint2;
    [SerializeField] private float durationTime = 1;

    private void Awake()
    {
        DoorSound = GetComponent<AudioSource>();
        
        DOTween.Init();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.CompareTag("Player"))
        {
            var go = other.gameObject.GetComponent<CharController>();
            if (go.inventory.checkKeycard())
            {
                if (gameObject.CompareTag("RedDoor") && go.inventory.checkColor() == KeyColor.Red)
                    moveTo();
                if (gameObject.CompareTag("GreenDoor") && go.inventory.checkColor() == KeyColor.Green)
                    moveTo();
                if (gameObject.CompareTag("BlueDoor") && go.inventory.checkColor() == KeyColor.Blue)
                    moveTo();
                else
                    print("no keycard");
            }
            
            if (gameObject.CompareTag("NormalDoor"))
            {
                moveTo();
                //MoveToPosition();
            }
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            moveBackTo();
    }

    private void moveTo()
    {
        animObject.transform.DOLocalMove(endPoint, durationTime).SetEase(Ease.InOutCirc); 
        if (animObject2 != null)
            animObject2.transform.DOLocalMove(endPoint2, durationTime).SetEase(Ease.InOutCirc); 
        DoorSound.PlayOneShot(doorClips[0]);
    }
    
    private void moveBackTo()
    {
        animObject.transform.DOLocalMove(startPoint, durationTime).SetEase(Ease.InOutCirc);
        if (animObject2 != null)
            animObject2.transform.DOLocalMove(startPoint2, durationTime).SetEase(Ease.InOutCirc);
        DoorSound.PlayOneShot(doorClips[1]);


    }
}
