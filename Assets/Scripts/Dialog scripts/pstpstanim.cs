using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pstpstanim : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;

    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
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
