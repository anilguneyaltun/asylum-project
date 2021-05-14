using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private SceneManager _sceneManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void changeFirstScene()
    {
        SceneManager.LoadScene("2ndLevel");
    }
}


