using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ItemInteract : MonoBehaviour {
    Player player;
    public int playerNum;

    public GameObject item, UI;

    Door door;
    public int keys = 0;

    ItemDescription des;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerNum);
	}
	
	// Update is called once per frame
	void Update () {
        if (item != null)
        {
            UI.SetActive(true);
        }
        if (player.GetButtonDown("Hide"))
        {
            if(item.tag == "Key")
            {
                keys++;
                item.SetActive(false);
            }

            if(item.tag == "Door")
            {
                door = item.GetComponent<Door>();
                print("got door");

                if(door.locked == true)
                {
                    if(keys <= 0)
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

            if(item.tag == "Description")
            {
                des = item.GetComponent<ItemDescription>();
                des.PlayDialogue();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door" || other.tag == "Key" || other.tag == "Description")
            item = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door" || other.tag == "Key" || other.tag == "Description")
            item = null;
    }
}
