using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public string[] dialogueOptions;
    public Text dialogueBox;
    public int dialogueNum;
    public float[] speechLength;

    public GameObject[] triggerOrder;
    public GameObject panel;

    public IEnumerator showDialogue()
    {
        panel.SetActive(true);
        dialogueBox.text = dialogueOptions[dialogueNum];
        yield return new WaitForSeconds(speechLength[dialogueNum]);
        dialogueBox.text = "";
        panel.SetActive(false);
        triggerOrder[dialogueNum].SetActive(false);
        dialogueNum++;
        triggerOrder[dialogueNum].SetActive(true);
    }
}
