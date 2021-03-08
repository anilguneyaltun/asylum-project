using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;
    public GameObject continueButton;
    public AudioClip[] sesarray;
    public AudioSource ses;
    public GameObject audiocontroller;
    public float targetTime = 0.0f;

    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }

    
  
    // Update is called once per frame
    void Update()
    {
        
       
    }
}
