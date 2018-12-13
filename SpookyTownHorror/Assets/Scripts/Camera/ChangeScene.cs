using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public int nextScene;
    public float delaySwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(delaySwitch);
        SceneManager.LoadScene(nextScene);
    }
}
