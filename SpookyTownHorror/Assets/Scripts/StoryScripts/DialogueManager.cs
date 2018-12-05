using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class DialogueManager : MonoBehaviour {
    public string[] dialogue;
    public float[] dialogueTiming;

    public int line = 0;
    public int stopLine;

    public Text dBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Dialogue()
    {
        StartCoroutine(nextLine());
        print("call");
    }

    IEnumerator nextLine()
    {
        dBox.text = dialogue[line];
        yield return new WaitForSeconds(dialogueTiming[line]);
        line++;

        if ((line - 1) < stopLine)
            Dialogue();
        else
        {
            dBox.text = "";
        }

        print("lined");
    }
}