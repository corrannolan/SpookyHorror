using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CircuitBoxInteract : MonoBehaviour {
    Player player;
    int playerNum = 0;

    AudioSource aS;
    public AudioClip startUp, generator;

    public AudioSource music;

    public GameObject[] lights;
    public ChangeScene cS;

    bool interactable = false;

    public GameObject monster;
    public float monsterDel;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerNum);

        aS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetButtonDown("Hide") && interactable == true)
        {
            StartCoroutine(circuitBreak());

            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().enabled = true;
            }

            cS.canUse = false;

            StartCoroutine(startMonster());
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            interactable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            interactable = false;
    }

    IEnumerator circuitBreak()
    {
        aS.PlayOneShot(startUp);
        yield return new WaitForSeconds(1.84f);
        aS.clip = generator;
        aS.Play();
        aS.loop = true;
    }

    IEnumerator startMonster()
    {
        yield return new WaitForSeconds(monsterDel);
        music.Play();
        monster.SetActive(true);
    }
}
