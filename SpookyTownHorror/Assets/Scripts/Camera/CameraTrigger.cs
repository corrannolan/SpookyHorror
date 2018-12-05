using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour {
    public GameObject connectedCam;
    //CinemachineVirtualCamera vCam;

    public GameObject player;
    PlayerMovement pM;

    Vector3 turnVect;

    bool switched = true;
    public float newDirDel = 0.365f;

    public bool singleEvent = false;

	// Use this for initialization
	void Start () {
        //vCam = connectedCam.GetComponent<CinemachineVirtualCamera>();

        pM = player.GetComponent<PlayerMovement>();
        //pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        turnVect = new Vector3(connectedCam.transform.forward.x, 0, connectedCam.transform.forward.z);

        print(gameObject.transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            
            connectedCam.SetActive(true);
            pM.currentCam = connectedCam;

            StartCoroutine(newDir());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();

        if (other.gameObject.tag == "Player")
            connectedCam.SetActive(false);

        if (singleEvent == true)
            Destroy(gameObject);
    }

    IEnumerator newDir()
    {
        yield return new WaitForSeconds(newDirDel);
        pM.NewDir();
    }
}
