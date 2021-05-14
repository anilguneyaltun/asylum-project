﻿using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
  public GameObject target;
  Vector3 offset;
  bool b;

  private void LateUpdate() {
    if(target == null)
    {
        target = GameObject.FindGameObjectWithTag("Player");
   
    }    
    else{
       
        if(!b){
            offset = transform.position - target.transform.position;
            b = true;
        }

        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 5);
        return;
    }
  }
}
