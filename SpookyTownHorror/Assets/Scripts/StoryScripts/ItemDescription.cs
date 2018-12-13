using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour {
    public GameObject dialoguePanel;
    public Text dialogueText;

    public string[] dialogue;
    public float dialogueTime;

    bool canInteract = true;

	// Use this for initialization
	void Start () {
        //dialogueText = dialoguePanel.GetComponent<Text>();
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
        dialoguePanel.SetActive(true);
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogueText.text = dialogue[i];
            yield return new WaitForSeconds(dialogueTime);
        }
        
        dialoguePanel.SetActive(false);
        canInteract = true;
    }
}
