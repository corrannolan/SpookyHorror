using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerTurn : MonoBehaviour {
    Player player;
    public int playerNum;

    public GameObject pMove;

    Rigidbody rB;
    public Transform parentDir;
    Vector3 turnDir;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerNum);

        rB = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = pMove.transform.position;

		if(player.GetAxis("TurnV") != 0 || player.GetAxis("TurnH") != 0)
        {
            Vector3 vDir = parentDir.transform.forward * player.GetAxis("TurnV");
            Vector3 hDir = parentDir.transform.right * player.GetAxis("TurnH");
            turnDir = new Vector3(hDir.x + vDir.x, 0, vDir.z + hDir.z);

            gameObject.transform.forward = turnDir;
        }
	}
}
