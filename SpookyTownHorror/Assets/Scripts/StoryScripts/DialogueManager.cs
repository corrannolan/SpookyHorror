using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public string[] dialogue;
    public float[] dialogueTiming;

    public int line = 0;
    public int stopLine;

    public Text dBox;
    public GameObject dialoguePanel;
    private PlayerMovement pm;
    public bool stopping;

    // Use this for initialization
    void Start () {

        pm = GameObject.Find("PlayerMove").GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Dialogue(bool stopPlayer)
    {
        StartCoroutine(nextLine());
        dialoguePanel.SetActive(true);
        if (stopPlayer)
        {
            pm.canMove = false;
            stopping = true;
        }
        print("call");
    }

    IEnumerator nextLine()
    {
        dBox.text = dialogue[line];
        yield return new WaitForSeconds(dialogueTiming[line]);
        line++;

        if ((line - 1) < stopLine)
            Dialogue(stopping);
        else
        {
            dBox.text = "";
            if (stopping)
            {
                pm.canMove = true;
                stopping = false;
            }
            dialoguePanel.SetActive(false);
        }

        print("lined");
    }
}