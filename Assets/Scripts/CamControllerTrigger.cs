using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerTrigger : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _gameObjects;
    CodeInput ci;
    public bool isOpen;
     void Start()
     {
        ci = GameObject.FindObjectOfType<CodeInput>();
        isOpen = ci.isOpen;
     }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            for (int i = 0; i < _gameObjects.Capacity; i++)
            {
                if (isOpen)
                    _gameObjects[i].SetActive(false);

            }
        }
    }
}
