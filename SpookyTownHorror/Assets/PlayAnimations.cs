using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayAnimations : MonoBehaviour {
    public bool isMoving;
    Player player;
    public int playerNum;
    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        player = ReInput.players.GetPlayer(playerNum);
    }

    // Update is called once per frame
    void Update() {

        if (player.GetAxis("MoveV") != 0 || player.GetAxis("MoveH") != 0)
        {
            animator.SetBool("isMoving", true);
            Debug.Log("Moving");
        }
        
      /*  else
        {
            animator.SetBool("isMoving", false);
            Debug.Log("Not Moving");

        }*/
    }
}
