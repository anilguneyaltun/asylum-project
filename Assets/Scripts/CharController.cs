using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
    #region
    bool isActive;
    public InventoryObject inventory;
    public GameObject inventoryPanel;
    
    [HideInInspector]public LayerMask clickableLayer;
    [HideInInspector]public GameObject activePlayer;
    [HideInInspector]public Vector3 moveTarget;
    [HideInInspector]public bool isInteractable;
    [HideInInspector]public bool pathReached;
    [HideInInspector]public bool canMove;
    [HideInInspector]public Quaternion rot;
    [HideInInspector]public GameObject currentInteractable;
    [HideInInspector]public bool isKeyGot;
    
    public EventVector3 OnClickEnviroment;
    private NavMeshAgent playerAgent;

    private Animator animator;

    private int speedId;
    private int rotateId;
    
    NavMeshAgent agent;

    private DialogManagerScript dms;
    private bool isConversation;


    #endregion
    public void Awake(){
        agent = GetComponent<NavMeshAgent>();
        dms = FindObjectOfType<DialogManagerScript>();
        
        
    }
    [HideInInspector]
    public void SetDestination(Vector3 destination) {
        agent.destination = destination;
        animator.SetFloat(speedId, 2f);
        if (agent.remainingDistance <= agent.stoppingDistance)
            animator.SetFloat(speedId, 0f);
        
    }

    public enum MoveFSM
    {
        findPosition,
        move,
        turnToFace,
        interact
    }

    #region 
    
    private void Start()
    {
        animator = GetComponent<Animator>();

        speedId = Animator.StringToHash("Speed");
        rotateId = Animator.StringToHash("Angle");

        playerAgent = this.GetComponent<NavMeshAgent>();
        canMove = true;
        pathReached = false;
        activePlayer = gameObject;
    }

    void Update()
    {
        if((inventory != null))
             openInventory();
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
        inventory.Container.Clear();
    }
    
    

    private void openInventory()
    {
        
        if (Input.GetKeyUp(KeyCode.I) && !isActive)
        {
            iTween.MoveTo(inventoryPanel, iTween.Hash("islocal", true,"x", 760, "time" ,1, "easetype", "spring"));
            //inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            isActive = true;
        }
        else if(Input.GetKeyUp(KeyCode.I) && isActive)
        {
            iTween.MoveTo(inventoryPanel, iTween.Hash("islocal", true,"x", 1200, "time" ,0.4, "easetype", "linear"));
            isActive = false;
        }
    }
}




