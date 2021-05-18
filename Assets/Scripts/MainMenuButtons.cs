using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject OptionsPanel;
    public void StartButton()
    {
        SceneManager.LoadScene("1stLevel");
    }

    public void OptionsPanelup()
    {
        OptionsPanel.SetActive(true);
    }

    public void OptionsPanelDown()
    {
        OptionsPanel.SetActive(false);
    }

    public void Exitbutton()
    {
        Application.Quit();
    }
}
