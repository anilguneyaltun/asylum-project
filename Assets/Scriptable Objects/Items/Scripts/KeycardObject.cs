using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
  Red,
  Blue,
  Green
}

[CreateAssetMenu(fileName = "New Keycard Object", menuName = "Inventory System/Items/Keycard")]
public class KeycardObject : Item
{
  public KeyColor _color;
  
  public void Awake()
  {
    type = ItemType.KeyCard;
  }
}
