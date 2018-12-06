using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Rewired;

public class Tutorial : MonoBehaviour {

    public GameObject UIHowTo;
    public Image HowToImage;
    private PlayerMovement pm;

    public string whichTu;

    private Player player;
    public int playerID = 0;

    public bool playAtStart, stopPlayer, goAway;

	// Use this for initialization
	void Start () {
        HowToImage = GetComponent<Image>();
        player = ReInput.players.GetPlayer(playerID);
        pm = GameObject.Find("PlayerMove").GetComponent<PlayerMovement>();
        if (playAtStart)
        {
            StartCoroutine(Learn(whichTu));
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetAnyButtonDown() && goAway)
        {
            HowToImage.DOFade(1f, 1f);
            UIHowTo.gameObject.SetActive(false);
            gameObject.SetActive(false);
            pm.canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (stopPlayer)
            {
                pm.canMove = false;
            }
            StartCoroutine(Learn(whichTu));
        }
    }

    IEnumerator Learn(string whichTutorial)
    {
        UIHowTo.SetActive(true);
        HowToImage.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);

        goAway = true;
    }
}
