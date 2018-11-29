using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class DialogueManager : MonoBehaviour {

    public string[] dialogueP1, dialogueP2;
    public Text dialogueBox;
    public int dialogueNum, p1Max, p2Max;
    public float[] speechLength;

    public GameObject[] triggerOrder;
    public GameObject panel;

    public IEnumerator showDialogue(int part)
    {
        if (part == 1 && dialogueNum != p1Max)
        {
            panel.SetActive(true);
            dialogueBox.text = dialogueP1[dialogueNum];
            yield return new WaitForSeconds(speechLength[dialogueNum]);
            dialogueBox.text = "";
            dialogueNum++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(showDialogue(1));
        }
        else if (part == 2 && dialogueNum != p2Max)
        {
            panel.SetActive(true);
            dialogueBox.text = dialogueP1[dialogueNum];
            yield return new WaitForSeconds(speechLength[dialogueNum]);
            dialogueBox.text = "";
            dialogueNum++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(showDialogue(2));
        }
        else
        {
            panel.SetActive(false);
            dialogueNum = 0;
        }
    }
}
