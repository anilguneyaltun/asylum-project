using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("Scenes/Fail");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
