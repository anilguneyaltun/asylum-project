using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using Random = System.Random;


public class AI : MonoBehaviour
{
    #region private members
    private int destPoint;
    private NavMeshAgent _agent;
    private float timer;
    
    #endregion

    #region public members
    
    [Header("AI Agent")]
    public GameObject prefab;
    public Animation anim;
    [Header("Patrol")]
    public Transform[] points;
    [Range(1.0f, 50.0f)] 
    public float patrolWaitTime = 1;

    #endregion

    private void Start()
    {
        timer = Time.deltaTime;
        _agent = GetComponent<NavMeshAgent>();

       
        doPatrol();
    }

    void doPatrol()
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


    private void Update()
    {
        if(!_agent.pathPending && _agent.remainingDistance < 0.1f)
            doPatrol();
    }
}
