using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public DialogueManager dm;
    public int dialogueCount;

	// Use this for initialization
	void Start () {
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dialogue")
        {
            StartCoroutine(dm.showDialogue(dialogueCount));
            dialogueCount++;
        }
    }
}
