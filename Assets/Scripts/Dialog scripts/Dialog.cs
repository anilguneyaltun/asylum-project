using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
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
    public float targetTime2 = 0.0f;

    public Image fadeout;
    public Image fadeout2;

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

    public void NextSentence()
    {
       
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            fadeout.canvasRenderer.SetAlpha(0.0f);
        }
      
    }
  
    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[0])
        {
            Debug.Log("1.cumle");
            ses.clip = sesarray[0];
            if (ses.isPlaying == false)
                ses.Play();
            fadeouct();
            
        }
        if (textDisplay.text == sentences[1])
        {
            Debug.Log("2.cumle");
            ses.clip = sesarray[1];
            if (ses.isPlaying == false)
                ses.Play();
        }
        if (textDisplay.text == sentences[2])
        {
            Debug.Log("3.cumle");
            ses.clip = sesarray[2];
            if (ses.isPlaying == false)
                ses.Play();
        }  if (textDisplay.text == sentences[3])
        {
            Debug.Log("4.cumle");
            ses.clip = sesarray[3];
            if (ses.isPlaying == false)
                ses.Play();
        }  
        if (textDisplay.text == sentences[4])
        {
            Debug.Log("5.cumle");
            ses.clip = sesarray[4];
            if (ses.isPlaying == false)
                ses.Play();
        }  
        if (textDisplay.text == sentences[5])
        {
            Debug.Log("6.cumle");
            ses.clip = sesarray[5];
            if (ses.isPlaying == false)
                ses.Play();
        }
        if (textDisplay.text == sentences[6])
        {
            Debug.Log("7.cumle");
            ses.clip = sesarray[6];
            if (ses.isPlaying == false)
                ses.Play();
        }if (textDisplay.text == sentences[7])
        {
            Debug.Log("8.cumle");
            ses.clip = sesarray[7];
            if (ses.isPlaying == false)
                ses.Play();
        }  
        if (textDisplay.text == sentences[8])
        {
            Debug.Log("9.cumle");
            ses.clip = sesarray[8];
            if (ses.isPlaying == false)
                ses.Play();
        }
        if (textDisplay.text == sentences[9])
        {
            Debug.Log("10.cumle");
            ses.clip = sesarray[9];
            if (ses.isPlaying == false)
                ses.Play();
        }if (textDisplay.text == sentences[10])
        {
            Debug.Log("11.cumle");
            ses.clip = sesarray[10];
            if (ses.isPlaying == false)
                ses.Play();
        }
        if (textDisplay.text == sentences[11])
        {
            Debug.Log("12.cumle");
            ses.clip = sesarray[11];
            if (ses.isPlaying == false)
                ses.Play();
        }
        if (textDisplay.text == sentences[12])
        {
            Debug.Log("13.cumle");
            ses.clip = sesarray[12];
            if (ses.isPlaying == false)
                ses.Play();
        }



        if (textDisplay.text == sentences[13])
        {
            targetTime += Time.deltaTime;
            Debug.Log("14.cumle");
            ses.clip = sesarray[11];
            if (ses.isPlaying == false)
                ses.Play();
            continueButton.SetActive(false);

        }

        if (textDisplay.text == sentences[14])
        {
            targetTime2 += Time.deltaTime;
            Debug.Log("15.cumle");
            ses.clip = sesarray[14];
            if (ses.isPlaying == false)
                ses.Play();
            continueButton.SetActive(false);

        }
        if (targetTime > 0.12f)
        {
            fadeout2.GetComponent<Animator>().enabled = true;
        }
        if (targetTime >= 7.0f)
        {
            SceneManager.LoadScene("SampleScene 1");
          
        }  if (targetTime2 >= 5.0f)
        {
            SceneManager.LoadScene("SampleScene 1");
          
        }

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
       
    }
    void fadeouct()
    {
        fadeout.CrossFadeAlpha(2, 2, false);
    }
}
