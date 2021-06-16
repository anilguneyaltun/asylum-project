using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int xStart;
    public int yStart;
    public int xSpace;
    public int ySpace;
    public int numOfCol;

    private Dictionary<InventoryObject.InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventoryObject.InventorySlot, GameObject>();
    
    void Start()
    {
        createDisplay();
    }

    void Update()
    {
        updateDisplay();
    }

    public void createDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPosition(i);
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 getPosition(int i)
    {
        return new Vector3(xStart + xSpace * (i % numOfCol), yStart + (-ySpace * (i / numOfCol)),0f);
    }
    

    public void updateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (!itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPosition(i);
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
