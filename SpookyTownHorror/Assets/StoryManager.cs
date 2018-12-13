using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    public static StoryManager sm = null;

    public bool emptyFloor1, emptyFloor2, emptyBasement, AfterBasement;

    void Awake()
    {
        if (sm == null)
            sm = this;
        else if (sm != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
