using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Rewired;

public class FadeInOut : MonoBehaviour {
    
    private Player player;
    public int playerID;

    public string nextScene;

    private Image panel;

	// Use this for initialization
	void Start () {
        panel = GetComponent<Image>();
        player = ReInput.players.GetPlayer(playerID);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetButtonDown("Hide"))
        {
            StartCoroutine(Fade());
        }
	}

    IEnumerator Fade()
    {
        panel.DOFade(1f, 1f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextScene);
    }
}
