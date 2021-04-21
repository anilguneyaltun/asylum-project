using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipments
{
    syringe,
    pen,
    gun
}

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : Item
{
    public Equipments equipment;
    public void Awake()
    {
        type = ItemType.Equipment;
    }

}
