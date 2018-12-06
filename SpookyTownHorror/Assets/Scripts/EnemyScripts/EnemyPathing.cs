using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour {
    NavMeshAgent nA;
    EnemyBehavior eB;

    public int currentSet = 0;

    public GameObject[] set1;
    public GameObject[] set2;
    public GameObject[] set3;

    public int point = 0;
    public bool following = false;
    bool pointSwitched = false;

    public float normalSpeed;
    public float runningSpeed;

	// Use this for initialization
	void Start () {
        nA = GetComponent<NavMeshAgent>();
        eB = GetComponent<EnemyBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
        if(eB.currentState == EnemyBehavior.State.Patrol)
        {
            if (currentSet == 0)
            {
                nA.destination = set1[point].transform.position;
            }
            else if (currentSet == 1)
            {
                if (set2[point] == null)
                {
                    point = 0;
                }
                nA.destination = set2[point].transform.position;
            }
            else if (currentSet == 2)
            {
                if (set3[point] == null)
                {
                    point = 0;
                }
                nA.destination = set3[point].transform.position;
            }
        }

        if (nA.remainingDistance < 0.05f)
        {
            if(pointSwitched == false)
            {
                pointSwitched = true;
                nA.speed = normalSpeed;
                NextPoint();
            }
        }
	}

    public void NextPoint()
    {
        point++;
        pointSwitched = false;

        if (point == set1.Length)
        {
            point = 0;
        }
        if (point == set2.Length)
        {
            point = 0;
        }
        if (point == set3.Length)
        {
            point = 0;
        }
    }

    public void NextSet()
    {
        point = 0;
        nA.speed = runningSpeed;
    }
}
