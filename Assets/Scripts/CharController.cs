using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
    #region
    public InventoryObject inventory;
    public GameObject inventoryPanel;
    public double rad = 5; 
    
    private bool isActive;
    private Animator animator;
    private int speedId;
    private NavMeshAgent agent;
    private DialogManagerScript dms;
    
    
    private double circum;
    private double PI = Math.PI;
   
    #endregion
    public void Awake()
    {
        circum = 2 * Math.PI * rad;
        agent = GetComponent<NavMeshAgent>();
        dms = FindObjectOfType<DialogManagerScript>();
    }
    public void SetDestination(Vector3 destination) 
    {
        if (!dms.isConversation)
            agent.destination = destination;
    }
    #region 
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        speedId = Animator.StringToHash("Speed");
        
     }

    void Update()
    {
        if((inventory != null))
             openInventory();
        
        animator.SetFloat(speedId, agent.velocity.magnitude);
    }
    #endregion

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemObject>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        if(!(inventory == null))
            inventory.Container.Clear();
    }
    
    private void openInventory()
    {
        if (Input.GetKeyUp(KeyCode.I) && !isActive)
        {
            iTween.MoveTo(inventoryPanel, iTween.Hash("islocal", true,"x", 760, "time" ,1, "easetype", "spring"));
            isActive = true;
        }
        else if(Input.GetKeyUp(KeyCode.I) && isActive)
        {
            iTween.MoveTo(inventoryPanel, iTween.Hash("islocal", true,"x", 1200, "time" ,0.4, "easetype", "linear"));
            isActive = false;
        }
    }

   
}




