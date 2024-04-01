using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTriggerController : MonoBehaviour
{
    public bool finalTriggerTrue;
    public GameObject easterEgg;

    // Start is called before the first frame update
    void Start()
    {
        finalTriggerTrue = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            finalTriggerTrue = true;
            easterEgg.SetActive(true);
        }
    }
}
