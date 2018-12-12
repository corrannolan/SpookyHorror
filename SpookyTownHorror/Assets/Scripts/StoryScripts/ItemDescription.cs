using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour {
    public GameObject dialogueBox;
    Text dialogueText;

    public string dialogue;
    public float dialogueTime;

    bool canInteract = true;

	// Use this for initialization
	void Start () {
        dialogueText = dialogueBox.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayDialogue()
    {
        if(canInteract == true)
            StartCoroutine(playDialogue());
    }

    IEnumerator playDialogue()
    {
        canInteract = false;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
        yield return new WaitForSeconds(dialogueTime);
        dialogueBox.SetActive(false);
        canInteract = true;
    }
}
