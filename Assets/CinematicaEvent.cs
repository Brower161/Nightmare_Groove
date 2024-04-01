using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaEvent : MonoBehaviour
{
    public float secondsToExit;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToExit());
    }

    private IEnumerator WaitToExit()
    {
        yield return new WaitForSeconds(secondsToExit);
        SceneManager.LoadScene("Creditos");
    }
}
