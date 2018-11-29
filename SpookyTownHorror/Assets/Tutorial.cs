using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Tutorial : MonoBehaviour {

    public int playerID;
    private Player player;

    public string tutorialTopic;

    public GameObject crouchUI, pickUpUI, hideUI, distractUI;
    private PlayerMovement pm;

    private CharacterMovement cm;

	// Use this for initialization
	void Start () {
        pm = GameObject.Find("PlayerMove").GetComponent<PlayerMovement>();
        cm = GameObject.Find("Theo").GetComponent<CharacterMovement>();

        player = ReInput.players.GetPlayer(playerID);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetButtonDown("Crouch") && pm.canMove == false)
        {
            cm.MoveNext();
            pm.canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (tutorialTopic == "crouch")
            {
                pm.canMove = false;
                crouchUI.SetActive(true);
                
            }
            else if (tutorialTopic == "pickUp")
            {

            }
            else if (tutorialTopic == "hide")
            {

            }
            else if (tutorialTopic == "distract")
            {

            }
        }
        
    }
}
