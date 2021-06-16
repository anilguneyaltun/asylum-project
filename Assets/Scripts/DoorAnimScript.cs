using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DoorAnimScript : MonoBehaviour
{
    public GameObject animObject;
    private AudioSource DoorSound;
    [SerializeField]
    private AudioClip[] doorClips;

    private void Awake()
    {
        DoorSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.CompareTag("Player"))
        {
            var go = other.gameObject.GetComponent<CharController>();
            if (go.inventory.checkKeycard())
            {
                if (gameObject.CompareTag("RedDoor") && go.inventory.checkColor() == KeyColor.Red)
                    MoveToPosition();
                if (gameObject.CompareTag("GreenDoor") && go.inventory.checkColor() == KeyColor.Green)
                    MoveToPosition();
                if (gameObject.CompareTag("BlueDoor") && go.inventory.checkColor() == KeyColor.Blue)
                    MoveToPosition();
                else
                    print("no keycard");
               
            }
        }
       
        if (gameObject.CompareTag("NormalDoor"))
        {
            MoveToPosition();
        }
            
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            MoveBackToPosition();
    }

    public void MoveToPosition()
    {
        iTween.MoveTo(animObject, iTween.Hash( "islocal", true,"z", -3,"time",0.7, "easetype", "EaseInCirc" ));
        DoorSound.PlayOneShot(doorClips[0]);
    }
    
    public void MoveBackToPosition()
    {
        iTween.MoveTo(animObject, iTween.Hash("islocal", true, "z", -4.727,"time",0.7, "easetype", "EaseInCirc", "delay", 1));
        DoorSound.PlayOneShot(doorClips[1]);
    }
}
