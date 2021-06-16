using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Sense : MonoBehaviour
{
    [Header("AI Senses")] 
    public float detectionRate = 0.1f;
    protected float elapsedTime = 0.0f;
    protected virtual void init(){}
    protected virtual void sense(){}
    
    private void Start()
    {
        elapsedTime = 0.0f;
        init();
    }
    private void Update()
    {
        sense();
    }
}

public class Perspective : Sense
{
    [SerializeField] private int FOV = 10;
    [SerializeField] private int viewRange = 50;
    private Vector3 rayDir;
    public Transform playerTransform;
    public bool isDetected = false;
    
 protected override void init()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void sense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate)
        {
            Detect();
        }
    }

  
    public void Detect()
    {
        RaycastHit hit;
       // rayDir = playerTransform.position - transform.position;
       rayDir = transform.forward;

        if (Vector3.Angle(rayDir, transform.forward) < FOV)
        {
            if(Physics.Raycast(transform.position, rayDir, out hit, viewRange))
            {
                if (hit.collider.tag == "Player")
                {
                    isDetected = true;
                }
                else
                {
                    isDetected = false;
                }
            }
         
        }
    }
    

    public void OnDrawGizmos()
    {
        Vector3 frontRay = transform.position + (transform.forward * viewRange);
        
        Vector3 leftRay = frontRay;
        leftRay.x += (FOV * 0.5f);
        Vector3 rightRay = frontRay;
        rightRay.x -= FOV * 0.5f;
        
    }
}


public class AI : Perspective
{
    #region private members
    private int destPoint;
    private NavMeshAgent _agent;
    private float timer;
    private Animator animator;
    private int speedID;
    private bool isArrested; 
    
    #endregion

    #region public members
    [Header("Patrol")] 
    public bool isPatrolling = false;
    public Transform[] points;
    [Range(1, 10)] 
    public int patrolWaitTime = 1;
    
    #endregion

    private void Start()
    {
        init();  
        animator = GetComponent<Animator>();
        speedID = Animator.StringToHash("Speed");
        timer = Time.deltaTime; 
        _agent = GetComponent<NavMeshAgent>();
    }

    void doPatrol()
    {
        
        if (isPatrolling)
        {
            if (points.Length == 0)
                return;
        
            timer += Time.deltaTime;
            if (timer - Time.deltaTime > patrolWaitTime)
            {
                timer = 0;
                _agent.destination = points[destPoint].position;
            }
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void moveToPlayer()
    {
        
            if (!(_agent.remainingDistance < 2.0f))
            {
                isPatrolling = false;
                _agent.destination = playerTransform.position;
                isArrested = true;
            }
            else
            {
                isPatrolling = true;
                isDetected = false;
            }
    }

    
    
    private void Update()
    {
        sense();
        if(!_agent.pathPending && _agent.remainingDistance < 0.1f)
            doPatrol();
        if(isDetected)
            moveToPlayer();

        if (isArrested)
        {
            PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Scenes/Fail");
        }
        
        animator.SetFloat(speedID, _agent.velocity.magnitude);
    }

  
}
