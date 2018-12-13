using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCam : MonoBehaviour {

    PlayerMovement pm;

	// Use this for initialization
	void Start () {
        pm = GameObject.Find("PlayerMove").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(pm.currentCam.transform);
	}
}
