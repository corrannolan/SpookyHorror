using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementLock : MonoBehaviour {
    ChangeScene cS;

    public ItemInteract iI;

    StoryManager sM;

	// Use this for initialization
	void Start () {
        cS = GetComponent<ChangeScene>();
        sM = GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(iI.keys <= 0)
        {
            cS.canUse = false;
        }
        else if(sM.AfterBasement == false && iI.keys > 0)
        {
            cS.canUse = true;
        }

        if (sM.AfterBasement == true)
            cS.canUse = false;
	}
}