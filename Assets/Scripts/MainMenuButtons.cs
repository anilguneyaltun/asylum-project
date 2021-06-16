using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsPanel;
    public float transitionTime = 1f;
    public Animator transition;
    public void StartButton()
    {
        LoadNextLevel();
    }

    public void OptionsPanelup()
    {
        OptionsPanel.SetActive(true);
    }

    public void OptionsPanelDown()
    {
        OptionsPanel.SetActive(false);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    public void Exitbutton()
    {
        Application.Quit();
    }
}
