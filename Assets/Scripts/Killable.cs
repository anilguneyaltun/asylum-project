﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Destroy(GameObject.Find("Neutral_Idle"));
            Destroy(GameObject.Find("Howtokillinfo"));
            Debug.Log("fff");
        }
    }
}
