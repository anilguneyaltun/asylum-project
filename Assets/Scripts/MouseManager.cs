using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;
    public EventVector3 OnClickEnviroment;


    void Update(){

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 50, clickableLayer.value))
        {
            bool isWall = false;
            if (hit.collider.gameObject.tag == "Wall")
            {
                //Cursor add
                isWall = true;
              
            }

            if(Input.GetMouseButtonDown(1)) 
            {
                if (!isWall)
                {
                    OnClickEnviroment.Invoke(hit.point);
                }

            }
           
        }
    }

}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }