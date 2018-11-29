using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Interact : MonoBehaviour
{

    Player player;
    public GameObject item, playerchar, ui;
    public bool door, key, distraction, other, interactable;
    // Use this for initialization
    void Start()
    {

        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (player.GetButtonDown("Hide"))
            {
                if (door)
                {

                }
                else if (key)
                {
                    print("keys");
                    //PlayerItems.keys++;
                }
                else if (distraction)
                {
                    //PlayerItems.distract = true;
                }
                else if (other)
                {

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ui.SetActive(true);
        interactable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
        interactable = false;
    }
}
