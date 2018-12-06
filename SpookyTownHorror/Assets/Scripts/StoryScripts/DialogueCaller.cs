using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour {
    public DialogueManager dM;
    public int startLine;
    public int stopLine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        dM.line = startLine;
        dM.stopLine = stopLine;
        dM.Dialogue();
    }
}
