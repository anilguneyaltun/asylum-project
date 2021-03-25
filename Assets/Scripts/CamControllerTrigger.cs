using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerTrigger : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _gameObjects;
    //TODO: also disable the animations
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _gameObjects.Capacity; i++)
            {
                _gameObjects[i].SetActive(false);
            }
        }
    }
}
