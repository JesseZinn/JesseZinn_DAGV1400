using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;
    public LayerMask whatIsGround;

    public float attackRange = 7f;
    private Vector3 patrolPoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        patrolPoint = transform.position;
    }
    private void Update()
    {
        if (target != null)
        {
            Vector3 targetDistance = target.position - transform.position;

            if (targetDistance.magnitude <= attackRange)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }
    private void Patrol()
    {
        agent.SetDestination(patrolPoint);

        Vector3 patrolPointDistance = patrolPoint - transform.position;
        if (patrolPointDistance.magnitude <= 0.5f)
        {
            float floatX = Random.Range(-5f, 5f);
            Vector3 testPoint = patrolPoint = new Vector3(transform.position.x + floatX, transform.position.y, transform.position.z);
            if (CheckPatrolPoint(testPoint) == true)
            {
                patrolPoint = testPoint;
            }
            else
            {
                return;
            }
        }
    }
    private bool CheckPatrolPoint(Vector3 point)
    {
        if (Physics.Raycast(point, -Vector3.up, 1f, whatIsGround))
        {
            return false;
        }
        else
        {
            return false;
        }
    }
}
