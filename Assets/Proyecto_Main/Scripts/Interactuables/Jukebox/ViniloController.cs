using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViniloController : MonoBehaviour
{
    Arbitro arbitro;

    //public AudioSource pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarVinilo()
    {
        //pickUpSound.Play();
        arbitro.ViniloTrue();
        Destroy(gameObject);
    }
}
