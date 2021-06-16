using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerTrigger : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _gameObjects;
    CodeInput ci;
    private bool isOpen;
     void Start()
     {
        ci = GameObject.FindObjectOfType<CodeInput>();
        isOpen = ci.isCorrect();
     }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            if(isOpen)
            {
                for (int i = 0; i < _gameObjects.Capacity; i++)
                {
                    
                        _gameObjects[i].SetActive(false);

                }
            }
            
        }
    }
}
