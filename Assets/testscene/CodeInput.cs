using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeInput : MonoBehaviour
{
    
    public GameObject objectToEnable;
    
    public string curPassword = "2546";
    public string input;
    public Text displayText;
    public GameObject displaytextField;

    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;
    public float codetimer = 0.0f;
    public float codetimer2 = 0.0f;
    Animator textanim;
    Animator spriteanim;
    private bool isOpen;
    public AudioSource keycodeAudio;
    [SerializeField]
    public GameObject[] cams;
    void Start()
    {
        
        btnClicked = 0;
        numOfGuesses = curPassword.Length;
        textanim = displayText.GetComponent<Animator>();
        spriteanim = displaytextField.GetComponent<Animator>();

    }

    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                codetimer += Time.deltaTime;
                spriteanim.enabled = true;

            }
            else
            {
                codetimer2 += Time.deltaTime;
                textanim.enabled = true;


            }
            if (codetimer2 >= 1.5f)
            {
                input = "";
                displayText.text = input.ToString();
                btnClicked = 0;
                codetimer2 = 0f;
                Debug.Log("invalid");
                displayText.GetComponent<Text>().color = Color.white;
                textanim.enabled = false;

            }
            if(codetimer>=1.5f)
            {
                input = "";
                btnClicked = 0;
                Debug.Log("correct");
                textanim.enabled = false;
                isOpen = true;
                objectToEnable.SetActive(false);
                for (int i=0;i<cams.Length;i++)
                {
                    cams[i].SetActive(false);
                }
                
                
            }

        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            keypadScreen = true;
            keycodeAudio.Play();
        }
    }
    void OnGUI()
    {/* 
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100.0f))
            {
                var selection = hit.transform;
                if(selection.CompareTag("keypad"))
                {
                    keypadScreen = true;
                    var selectionRender = selection.GetComponent<Renderer>();
                    if(selectionRender !=null)
                    {
                        keypadScreen = true;
                    }
                }
            }

        }*/
        if(keypadScreen)
        {
            objectToEnable.SetActive(true);
            
        }
        
    }

   
    public void ValueEntered(string valueEntered)
    {
        switch(valueEntered)
        {
            case "Q":
              
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C":
                input = "";
                btnClicked = 0;
                displayText.text = input.ToString();
                break;

            default:
                btnClicked++;
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }
    }

    public bool isCorrect()
    {
        return isOpen;
    }
}
