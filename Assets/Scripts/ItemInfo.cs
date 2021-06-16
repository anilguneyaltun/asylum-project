using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    private DialogueTrigger trigger;
    private static GameObject gameO;
    private InventoryObject inventoryObject;

    public static void getObject(GameObject go)
    {
        gameO  = new GameObject("Trigger");
        var item = go.GetComponent<ItemObject>();
        string[] desc = new string[1];
        desc[0] = item.item.description;
        gameO.AddComponent<DialogueTrigger>()._dialogue = new Dialogue(item.item.name, desc);
        
    }
    public void displayOnDialogue()
    {
        gameO.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}


