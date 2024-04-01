using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    PlayerController controller;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.currentSpeed > 0)
        {
            //audioSource.Play();
        }
    }
}
