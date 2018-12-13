using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject thing1;
    AudioSource audioData;

    // Use this for initialization
    void Start () {

    }
    private void OnTriggerEnter(Collider other)
    {
       if (StoryManager.sm.AfterBasement == true)
      {
            thing1.gameObject.SetActive(true);
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
