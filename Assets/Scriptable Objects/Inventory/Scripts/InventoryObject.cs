using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    
    
    public void AddItem(Item _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public bool checkKeycard()
    {
        bool hasKeycard = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item.type == ItemType.KeyCard)
            {
                
                hasKeycard = true;
            }
        }
        return hasKeycard;
    }

    public KeyColor checkColor()
    {
        KeyColor color = KeyColor.None;
        for (int i = 0; i < Container.Count; i++)
        {
            
            if (Container[i].item.type == ItemType.KeyCard)
            {
                if (Container[i].item.color == KeyColor.Red)
                {
                    color = KeyColor.Red;
                }
                if (Container[i].item.color == KeyColor.Blue)
                {
                    color = KeyColor.Blue;
                }
                if (Container[i].item.color == KeyColor.Green)
                {
                    color = KeyColor.Green;
                }
                
            }
           
        }
        return color;
    }



    [System.Serializable]
    public class InventorySlot
    {
        public Item item;
        public int amount;


        public InventorySlot(Item _item, int _amount)
        {
            item = _item;
            amount = _amount;

        }

        public void AddAmount(int value)
        {
            amount += value;
        }
    }

}
