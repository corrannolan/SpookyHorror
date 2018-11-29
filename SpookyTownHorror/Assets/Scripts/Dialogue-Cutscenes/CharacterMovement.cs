using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour {
    public NavMeshAgent nM;

    public GameObject[] points;

    public int currentPoint = 0;
    Transform desPoint;

    bool stopped = false;

    // Use this for initialization
    void Start()
    {
        desPoint = points[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped != true)
        {
            nM.isStopped = false;
        }

        if (nM.remainingDistance < 0.1f && stopped == false)
        {
            stopped = true;
            nM.isStopped = true;
        }
    }

    private void FixedUpdate()
    {
        nM.destination = desPoint.position;
    }

    void NextPoint()
    {
        currentPoint++;
        desPoint = points[currentPoint].transform;
    }

    public void MoveNext()
    {
        NextPoint();
        stopped = false;
    }
}
