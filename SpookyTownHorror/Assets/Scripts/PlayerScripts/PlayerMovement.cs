using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Cinemachine;

public class PlayerMovement : MonoBehaviour {
    Player player;
    public int playerNum;

    Rigidbody rB;
    Vector3 dir;
    public float moveSpeed;

    PlayerTurn pT;

    public GameObject currentCam;
    //CinemachineVirtualCamera vCam;

    bool moving = false;
    bool gotCam = true;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerNum);

        rB = gameObject.GetComponent<Rigidbody>();
        pT = gameObject.GetComponentInChildren<PlayerTurn>();

        gameObject.transform.forward = new Vector3(currentCam.transform.forward.x, 0, currentCam.transform.forward.z);
        pT.parentDir = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        print(gameObject.transform.forward);

        if(gotCam == false && moving == false)
        {
            gotCam = true;
            gameObject.transform.forward = new Vector3(currentCam.transform.forward.x, 0, currentCam.transform.forward.z);
            pT.parentDir = gameObject.transform;
        }

        if (player.GetAxis("MoveV") != 0 || player.GetAxis("MoveH") != 0)
        {
            moving = true;

            Vector3 fDir = gameObject.transform.forward * (player.GetAxisRaw("MoveV"));
            Vector3 rDir = gameObject.transform.right * (player.GetAxisRaw("MoveH"));
            dir = new Vector3(fDir.x + rDir.x, rB.velocity.y, rDir.z + fDir.z);

            rB.velocity = dir * moveSpeed;
        }
        else
            moving = false;
	}

    public void NewDir()
    {
        gotCam = false;
    }
}
