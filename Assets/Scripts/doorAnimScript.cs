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
            MoveToPosition();
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
