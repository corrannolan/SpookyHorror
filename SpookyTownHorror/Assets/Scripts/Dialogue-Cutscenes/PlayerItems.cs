using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {

    public static int keys;
    public static bool distract;
	// Use this for initialization
	void Start () {
        distract = false;	
	}
	
	// Update is called once per frame
	void Update () {
        print(keys);
        if (distract)
        {
            print("distracts");
        }
	}
}
