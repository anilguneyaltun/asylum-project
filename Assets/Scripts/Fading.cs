using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
   public GameObject go;
   public GameObject buttonGO;
   public void ScaleTo()
   {
      iTween.ScaleTo(go, iTween.Hash("scale", new Vector3(0,0,0), "time" , 5, "easetype", "linear"));
      buttonGO.SetActive(false);
   }
}
