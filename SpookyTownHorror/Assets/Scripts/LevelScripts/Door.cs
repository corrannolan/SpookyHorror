using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    Rigidbody rB;
    HingeJoint hJ;
    JointMotor dummyMot;

    public bool locked;

    bool doorStop = false;
    bool opening = false;

	// Use this for initialization
	void Start () {
        rB = GetComponent<Rigidbody>();
        hJ = GetComponent<HingeJoint>();
	}
	
	// Update is called once per frame
	void Update () {
		if(doorStop == true)
        {
            rB.angularVelocity = Vector3.zero;
            rB.velocity = Vector3.zero;
        }
	}

    public void Open()
    {
        if(opening == false)
            StartCoroutine(open());
    }

    IEnumerator open()
    {
        opening = true;
        doorStop = false;
        hJ.useMotor = true;
        yield return new WaitForSeconds(4);
        hJ.useMotor = false;
        doorStop = true;
        yield return new WaitForSeconds(4);
        doorStop = false;
        dummyMot.targetVelocity = 25;
        dummyMot.force = 25;
        hJ.motor = dummyMot;
        hJ.useMotor = true;
        yield return new WaitForSeconds(4);
        hJ.useMotor = false;
        doorStop = true;
        dummyMot.targetVelocity = -25;
        dummyMot.force = 25;
        hJ.motor = dummyMot;
        opening = false;
    }
}
