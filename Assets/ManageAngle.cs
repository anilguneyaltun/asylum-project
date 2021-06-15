using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAngle : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 pos;
    private Vector3 rayEndPos;
    private MouseManager mm; 
    
    void Start()
    {

        mm = FindObjectOfType<MouseManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}
