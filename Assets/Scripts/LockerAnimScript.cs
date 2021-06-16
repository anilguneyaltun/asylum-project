using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LockerAnimScript : MonoBehaviour
{
    [SerializeField]private GameObject objectToRotate;
    [SerializeField] private Vector3 endPos;
    
    public void openLocker()
    {
        objectToRotate.transform.DOLocalRotate(endPos, 2).SetEase(Ease.Linear);
    }
   
}
