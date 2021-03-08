using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;

    public EventVector3 OnClickEnviroment;

    void Update(){
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 150, clickableLayer.value))
        {
            if(Input.GetMouseButtonDown(0)){
                OnClickEnviroment.Invoke(hit.point);
               
            }
        }
    }

}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }