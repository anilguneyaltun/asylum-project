using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
   public Dialogue _dialogue;

   public void TriggerDialogue()
   {
      FindObjectOfType<DialogManagerScript>().StartDialogue(_dialogue);
   }

   private void OnTriggerEnter(Collider other)
   {
      if(other.gameObject.CompareTag("Player"))
         FindObjectOfType<DialogManagerScript>().StartDialogue(_dialogue);
   }


   
}
