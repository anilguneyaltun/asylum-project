using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Keycard Object", menuName = "Inventory System/Items/Keycard")]
public class KeycardObject : Item
{
  public void Awake()
  {
    type = ItemType.KeyCard;
  } 
}
