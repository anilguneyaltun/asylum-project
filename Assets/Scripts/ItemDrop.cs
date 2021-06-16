using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
   private InventoryObject inventoryObject;
   private ItemObject obj;
   CharController character; 

   private void Start()
   {
       character = FindObjectOfType<CharController>();
       inventoryObject = character.inventory;
       
   }

   private void Update()
   {
       inventoryObject = character.inventory;
   }

   public void dropItem()
   {
     
   } 
}
