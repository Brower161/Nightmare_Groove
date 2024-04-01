using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContractEvent : MonoBehaviour
{
    public float secondsToExit;
    public Animator fadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToExit());
    }

    private IEnumerator WaitToExit()
    {
        yield return new WaitForSeconds(secondsToExit);
        fadeAnim.Play("FadeIn");
    }

    public void fadein()
    {
        SceneManager.LoadScene("CheckMainScene 1");
    }
}
