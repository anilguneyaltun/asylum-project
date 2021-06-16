using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]private float range = 100.0f;
    private int damage;
    public LayerMask clickableLayer;
    private MouseManager MM;
    private Vector3 pos;
    private Vector3 rayEndPos;
    private LineRenderer lr; 
    
   // [SerializeField] private GameObject shootingDir;
    
    private void Start()
    {
        MM = FindObjectOfType<MouseManager>();
        lr = gameObject.AddComponent<LineRenderer>();
        
    }

    private void FixedUpdate()
    {
        
        doShoot();
        lr.SetPosition(0, transform.TransformDirection(Vector3.forward));
        lr.startColor = Color.green;
        //renderLine();
        
    }

    private void doShoot()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit,Mathf.Infinity, clickableLayer))
        {
            if (MM.isShooting())
            {
                if (hit.collider.name == "Guard")
                {
                    print("y");
                }
            }
        }
    }

    void renderLine()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
          
        }
    }
    
}
