using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerHide : MonoBehaviour
{
    Player player;
    public int playerNum;

    CapsuleCollider cC;
    public float crouchHeight = 0.85f;
    MeshRenderer mR;
    Rigidbody rB;

    PlayerMovement pM;

    bool canHide = false;
    public string unhiddenTag;
    public string hiddenTag;

    // Use this for initialization
    void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);

        cC = gameObject.GetComponent<CapsuleCollider>();
        mR = gameObject.GetComponentInChildren<MeshRenderer>();
        rB = gameObject.GetComponent<Rigidbody>();

        pM = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButton("Crouch"))
        {
            cC.height = crouchHeight;
            cC.center = new Vector3(0, -0.5f, 0);
        }
        else
        {
            cC.center = Vector3.zero;
            cC.height = 2;
        }

        if (player.GetButtonDown("Hide"))
        {
            if(canHide == true)
            {
                gameObject.tag = hiddenTag;
                pM.canMove = false;
                rB.constraints = RigidbodyConstraints.FreezePosition;
                mR.enabled = false;
            }
        }
        else if (player.GetButtonUp("Hide"))
        {
            if(canHide == true)
            {
                gameObject.tag = unhiddenTag;
                mR.enabled = true;
                rB.constraints = RigidbodyConstraints.None;
                rB.constraints = RigidbodyConstraints.FreezeRotation;
                pM.canMove = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hide")
        {
            canHide = true;
            print("canHide");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hide")
        {
            canHide = true;
            print("cantHide");
        }
    }
}