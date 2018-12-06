﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ItemInteract : MonoBehaviour {
    Player player;
    public int playerNum;

    public GameObject item;

    Door door;
    bool hasKey = false;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerNum);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetButtonDown("Hide"))
        {
            if(item.tag == "Key")
            {
                hasKey = true;
                item.SetActive(false);
            }

            if(item.tag == "Door")
            {
                door = item.GetComponent<Door>();
                print("got door");

                if(door.locked == true)
                {
                    if(hasKey == false)
                    {
                        //locked UI pop-up
                    }
                    else
                    {
                        door.locked = false;
                    }
                }

                if(door.locked == false)
                {
                    door.Open();
                    print("open door called");
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door" || other.tag == "Key")
            item = other.gameObject;
    }
}
