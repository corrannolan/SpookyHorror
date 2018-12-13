using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeTheo : MonoBehaviour {

    public GameObject theo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theo.SetActive(false);
        }
    }
}
