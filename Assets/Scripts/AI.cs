using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class Sense : MonoBehaviour
{
    [Header("AI Senses")] 
    public float detectionRate = 1.0f;
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
    private Transform playerTransform;

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
        rayDir = playerTransform.position - transform.position;

        if (Vector3.Angle(rayDir, transform.forward) < FOV)
        {
            if(Physics.Raycast(transform.position, rayDir, out hit, viewRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    print("hit");
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
        rightRay.x -= FOV;

        Debug.DrawLine(transform.position, frontRay, Color.red);
        Debug.DrawLine(transform.position, rightRay, Color.green);
        Debug.DrawLine(transform.position, leftRay, Color.green);
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
        animator = GetComponent<Animator>();
        speedID = Animator.StringToHash("Speed");
        init();  
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
    
    private void Update()
    {
        sense();
        if(!_agent.pathPending && _agent.remainingDistance < 0.1f)
            doPatrol();
       
        animator.SetFloat(speedID, _agent.velocity.magnitude);
       
    }
}
