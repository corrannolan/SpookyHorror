using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour {
    public DialogueManager dM;
    public int startLine;
    public int stopLine;

    public GameObject nextTrigger;

    bool called = false;

    public bool stopPlayer, lastBox, floor1, floor2, yard;

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
            if (yard)
            {
                dM.line = startLine;
                dM.stopLine = stopLine;
                dM.Dialogue(stopPlayer);
            }
            else if (StoryManager.sm.AfterBasement == false && (StoryManager.sm.emptyFloor1 == false && floor1) && gameObject.CompareTag("DialogueA"))
            {
                dM.line = startLine;
                dM.stopLine = stopLine;
                dM.Dialogue(stopPlayer);
                if (lastBox)
                {
                    StoryManager.sm.emptyFloor1 = true;
                }
            }
            else if (StoryManager.sm.AfterBasement == false && (StoryManager.sm.emptyFloor2 == false && floor2) && gameObject.CompareTag("DialogueA"))
            {
                dM.line = startLine;
                dM.stopLine = stopLine;
                dM.Dialogue(stopPlayer);
                if (lastBox)
                {
                    StoryManager.sm.emptyFloor2 = true;
                }
            }
            else if (StoryManager.sm.AfterBasement == true && (StoryManager.sm.emptyFloor1 == false && floor1) && gameObject.CompareTag("DialogueB"))
            {
                dM.line = startLine;
                dM.stopLine = stopLine;
                dM.Dialogue(stopPlayer);
                if (lastBox)
                {
                    StoryManager.sm.emptyFloor1 = true;
                }
            }
            else if (StoryManager.sm.AfterBasement == true && (StoryManager.sm.emptyFloor2 == false && floor2) && gameObject.CompareTag("DialogueB"))
            {
                dM.line = startLine;
                dM.stopLine = stopLine;
                dM.Dialogue(stopPlayer);
                if (lastBox)
                {
                    StoryManager.sm.emptyFloor2 = true;
                }
            }
            else if (StoryManager.sm.AfterBasement == false && StoryManager.sm.emptyBasement == false && gameObject.CompareTag("Dialogue"))
            {
                dM.line = startLine;
                dM.stopLine = stopLine;
                dM.Dialogue(stopPlayer);
                if (lastBox)
                {
                    StoryManager.sm.emptyFloor1 = false;
                    StoryManager.sm.emptyFloor2 = false;
                    StoryManager.sm.emptyBasement = true;
                    StoryManager.sm.AfterBasement = true;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
            if (nextTrigger != null)
                nextTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
