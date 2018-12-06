using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour {
    public DialogueManager dM;
    public int startLine;
    public int stopLine;

    public GameObject nextTrigger;

    bool called = false;

    public bool stopPlayer;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dM.line = startLine;
            dM.stopLine = stopLine;
            dM.Dialogue(stopPlayer);
            if (nextTrigger != null)
                nextTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
