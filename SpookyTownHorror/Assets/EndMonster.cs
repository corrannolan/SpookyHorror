using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMonster : MonoBehaviour {

    public GameObject monster;
    public Image fade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(spawnMonster());
        }
    }

    IEnumerator spawnMonster()
    {
        yield return new WaitForSeconds(50f);
        monster.SetActive(true);
        yield return new WaitForSeconds(21f);
        fade.DOFade(1f, 1f);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("End");
    }
}
