using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;
    public TextMeshProUGUI textBox;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            textBox.text = "Press E to kill the Asylum Guard.";
    
    }

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

    
}
