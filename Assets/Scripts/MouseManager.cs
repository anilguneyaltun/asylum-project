using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;
    public EventVector3 OnClickEnviroment;
    public InventoryObject inventory;
    public Texture2D mainCursor;
    public Texture2D moveToCursor;
    
    float timer = 0;
    private CharController charGO;
    private GameObject go;
    private static bool isAttack = false;
    private bool hasGun = false;
    private bool isShooted;
    private bool isDead;
    private void Start()
    {
        timer = Time.deltaTime;
        charGO = FindObjectOfType<CharController>();
        hasGun = true;
    }

    void Update(){
        
       // if(!Application.isEditor)
          //  Cursor.SetCursor(moveToCursor, Vector2.zero, CursorMode.Auto);
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 50, clickableLayer.value))
        {
            
            bool isWall = hit.collider.gameObject.tag == "Wall";
            
            if(isWall)
                Cursor.SetCursor(mainCursor, Vector2.zero, CursorMode.Auto);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Collectable")
                {
                    go = hit.collider.gameObject;
                    addItem();
                    ItemInfo.getObject(go);
                }
            
                if (hasGun)
                {
                    if (hit.collider.gameObject.tag == "Guard")
                    {
                        print("hit");
                        isShooted = true;
                    }
                }

                if (hit.collider.gameObject.tag == "Doctor" || hit.collider.gameObject.tag == "Guard")
                {
                    
                    if (inventory.checkEquipment())
                    {
                      
                        isAttack = true;
                        StartCoroutine(waitForSec());
                        
                        GameObject go = hit.collider.gameObject;
                        Animator animator = go.gameObject.GetComponent<Animator>();
                        animator.SetBool("isDead", true);
                        
                        
                    }
                }
               
    
            }
            if(Input.GetMouseButtonDown(1)) 
            {
                if (!isWall)
                    OnClickEnviroment.Invoke(hit.point);
            }
        }
     
    }

    IEnumerator waitForSec()
    {
        yield return new WaitForSeconds(0.25f);
        isAttack = false;
    }
    void addItem()
    {
        //TODO: ADD RANGE
        var item = go.GetComponent<ItemObject>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(go.gameObject);
        }
    }

    public static bool isAttacking()
    {
        return isAttack;
    }

    public bool isShooting()
    {
        return isShooted;
    }
  
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }