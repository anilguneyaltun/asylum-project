using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Default,
    KeyCard,
    Equipment
}

public abstract class Item : ScriptableObject
{
    public GameObject prefab;

    public ItemType type;
    [TextArea(15,30)]
    public string description;

}
