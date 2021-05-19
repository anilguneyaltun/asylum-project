using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class doorAnimScript : MonoBehaviour
{
    public GameObject animObject;
    
    
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
        iTween.MoveTo(animObject, iTween.Hash( "islocal", true,"z", -3,"time",1, "easetype", "EaseInCirc" ));
    }
    
    public void MoveBackToPosition()
    {
        iTween.MoveTo(animObject, iTween.Hash("islocal", true, "z", -4.727,"time",1, "easetype", "EaseInCirc", "delay", 1));
    }
}
