using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : MonoBehaviour
{
    public GameObject killkey;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("dead");



            killkey.SetActive(true);

        }
     
       
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
