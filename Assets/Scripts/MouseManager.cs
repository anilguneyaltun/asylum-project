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
    
    private GameObject go;

    void Update(){
        
       // if(!Application.isEditor)
          //  Cursor.SetCursor(moveToCursor, Vector2.zero, CursorMode.Auto);
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 50, clickableLayer.value))
        {
            
            bool isWall = false;
            bool isObject = false;
            bool isUI = false;
            if (hit.collider.gameObject.tag == "Wall")
            {
                isWall = true;
            }
            if(isWall)
                Cursor.SetCursor(mainCursor, Vector2.zero, CursorMode.Auto);
            
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider.gameObject.tag == "Collectable")
                {
                    go = hit.collider.gameObject;
                    addItem();
                    ItemInfo.getObject(go);
                }
            }
            if(Input.GetMouseButtonDown(1)) 
            {
                if (!isWall)
                    OnClickEnviroment.Invoke(hit.point);
            }
        }
     
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
    
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }