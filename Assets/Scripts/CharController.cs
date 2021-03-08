using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
    #region 
    public EventVector3 OnClickEnviroment;
    private NavMeshAgent playerAgent;
    public LayerMask clickableLayer;
    public GameObject activePlayer;

    private Animator animator;

    private int speedId;
    private int rotateId;

    public Vector3 moveTarget;

    public bool isInteractable;
    public bool pathReached;
    public bool canMove;

    public Quaternion rot;

    public GameObject currentInteractable;

    NavMeshAgent agent; 

    public bool isKeyGot;

    #endregion
    public void Awake(){
        agent = GetComponent<NavMeshAgent>();

    }

    public void SetDestination(Vector3 destination) {
        agent.destination = destination;
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
        animator = this.GetComponent<Animator>();

        speedId = Animator.StringToHash("Speed");
        rotateId = Animator.StringToHash("Angle");

        playerAgent = this.GetComponent<NavMeshAgent>();
        canMove = true;
        pathReached = false;
        activePlayer = this.gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 150, clickableLayer.value))
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClickEnviroment.Invoke(hit.point);
                
                animator.SetFloat(speedId, 3f);
            }
          
           
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetFloat(speedId, 4f);
                OnClickEnviroment.Invoke(hit.point);
            }
        }
        if (!playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                animator.SetFloat(speedId, 0f);

                pathReached = true;


            }
        }

    }



    public void Move()
    {
        if (!playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                animator.SetFloat(speedId, 0f);

                pathReached = true;

               
            }
        }

    }

    public void TurnToFace()
    {
        if (currentInteractable != null)
        {
            if (pathReached == true)
            {
                Vector3 dir = currentInteractable.transform.position - transform.position;
                dir.y = 0;
                rot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, 5f * Time.deltaTime);

                if ((rot.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .01)
                {
                    pathReached = false;
                    
                   
                }
            }
        }
        else if (currentInteractable == null)
        {
           
        }
    }

    private void GetInteraction()
    {
        if (canMove)
        {
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;
            if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
            {



            }
            else
            {
                if (currentInteractable != null)
                {
                    //currentInteractable.GetComponent<Interactable>().isClicked = false;
                    currentInteractable = null;
                }
                isInteractable = false;

                moveTarget = interactionInfo.point;
                playerAgent.destination = interactionInfo.point;


                

                pathReached = false;
                
            }
        }
    }
#endregion
}




