using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerSc : MonoBehaviour
{
    public GameObject textTarget;
   
    
   

    void Start()
    {
        textTarget.SetActive(false);
    }

 
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
     
        
    }

   
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("girdi");

        if (collider.gameObject.tag == "Player")
        {
            textTarget.SetActive(true);
        }
    }
}
