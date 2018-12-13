using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementUnlock : MonoBehaviour {
    public ChangeScene cS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cS.canUse = true;
        }
    }
}
