using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementLock : MonoBehaviour {
    ChangeScene cS;

    StoryManager sM;

	// Use this for initialization
	void Start () {
        cS = GetComponent<ChangeScene>();
        sM = GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sM.AfterBasement == true)
            cS.canUse = false;
	}
}