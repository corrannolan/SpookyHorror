// Based on Unity's Interface Finite State Machine tutorial

using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemyBehavior : MonoBehaviour
{

    // Possible behavior states
    public enum State
    {
        Patrol,
        Alert,
        Chase
    }

    private State currentState = State.Patrol; // Patrol is the default behavior

    public Transform eyes;      // Set to a gameobject to position raycast origin
    public Transform lowRaycast;
    public float sightRange;    // How far can the agent see
    public float lowSightRange;
    public Vector3 sightOffset = new Vector3(0, .5f, 0);    // Adjustments to sight raycast

    // Navmesh Agent component
    private NavMeshAgent navMeshAgent;
    private Transform chaseTarget;      // Set when in Chase state

    public Transform[] wayPoints;   // Array containing sequential waypoints
    private int nextWayPoint;       // Waypoint to move towards


    public float searchingDuration = 2f;        // How long to remain in Search state
    public float searchingTurnSpeed = 120f;     // Speed of search sweep
    private float searchTimer;                  // Keep track of time spent searching for target

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Look();
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Alert:
                Search();
                break;
            case State.Chase:
                Chase();
                break;
        }
    }

    // Look for target
    private void Look()
    {

        RaycastHit lowhit;
        RaycastHit hit;

        if (currentState == State.Chase)
        {
            Vector3 enemyToTarget = (chaseTarget.position + sightOffset) - eyes.transform.position;
            Vector3 lowEnemyToTarget = (chaseTarget.position + sightOffset) - lowRaycast.transform.position;
            Debug.DrawRay(eyes.position, enemyToTarget, Color.red);
            Debug.DrawRay(eyes.position, lowEnemyToTarget, Color.red);


            if (Physics.Raycast(eyes.transform.position, enemyToTarget, out hit, sightRange)) 
            {
                if (hit.collider.CompareTag("Player"))
                {
                    chaseTarget = hit.transform;
                }
                
            }
            else if (Physics.Raycast(lowRaycast.transform.position, lowEnemyToTarget, out lowhit, lowSightRange))
            {
                if (lowhit.collider.CompareTag("Player"))
                {
                    chaseTarget = lowhit.transform;
                }
            }
            else
            {
                currentState = State.Alert;
            }
        }

        else
        {
            Debug.DrawRay(eyes.transform.position, eyes.forward * sightRange, Color.green);
            Debug.DrawRay(lowRaycast.transform.position, lowRaycast.forward * lowSightRange, Color.green);
            if (Physics.Raycast(eyes.transform.position, eyes.forward, out hit, sightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    chaseTarget = hit.transform;
                    currentState = State.Chase;
                }
            }
            else if (Physics.Raycast(lowRaycast.transform.position, lowRaycast.forward, out lowhit, lowSightRange))
            {
                chaseTarget = lowhit.transform;
                currentState = State.Chase;
            }
        }
    }

    private void Patrol()
    {
        navMeshAgent.destination = wayPoints[nextWayPoint].position;
        navMeshAgent.isStopped = false;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;

        }

    }

    private void Search()
    {
        navMeshAgent.isStopped = true;
        transform.Rotate(0, searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if (searchTimer >= searchingDuration)
        {
            currentState = State.Patrol;
            searchTimer = 0;
        }
    }

    private void Chase()
    {
        navMeshAgent.destination = chaseTarget.position;
        navMeshAgent.isStopped = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentState = State.Alert;
        }

    }

}
