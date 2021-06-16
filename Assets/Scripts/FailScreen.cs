using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour
{
    public Animator transition;
    public float timerFail;
    public bool timerstart = false;
    public void TryAgain()
    {
        timerstart = true;
        transition.SetTrigger("Start");
    }
    private void Update()
    {
        if(timerstart)
            timerFail += Time.deltaTime;
        if(timerFail>=1.0f)
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

}
