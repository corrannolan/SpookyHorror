using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerTest : MonoBehaviour {

    public string whichScene;
    public Text dialogueBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ping");
            StartCoroutine(playScene(whichScene));
        }
    }

    IEnumerator playScene(string whichScene)
    {
        if (whichScene == "tutorial.one")
        {
            yield return new WaitForSeconds(.5f);
            dialogueBox.text = "testing...";
            yield return new WaitForSeconds(1f);
            dialogueBox.text = "testing one";
            yield return new WaitForSeconds(1f);
            dialogueBox.text = "testing...one...two...";
            yield return new WaitForSeconds(1f);
            dialogueBox.text = "";
            gameObject.SetActive(false);
        }
        else if (whichScene == "tutorial.two")
        {

        }
    }
}
