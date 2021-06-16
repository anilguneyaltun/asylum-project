using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAI : MonoBehaviour
{
    public InventoryObject inventory;
    public List<InventoryObject.InventorySlot> Container = new List<InventoryObject.InventorySlot>();

    public void RemoveItem(Item _item, int _amount)
    {
        if (_amount <= 0)
        {
            Container.Clear();
        }
        
        bool hasItem = true;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].RemoveAmount(_amount);
                hasItem = false;
                break;
            }
        }
    }
}
