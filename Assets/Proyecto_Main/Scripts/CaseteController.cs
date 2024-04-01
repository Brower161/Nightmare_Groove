using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseteController : MonoBehaviour
{
    Arbitro arbitro;

    //public AudioSource pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>();
    }
    public void ActivarObjeto()
    {
        //pickUpSound.Play();
        arbitro.CaseteTrue();
        Destroy(gameObject);
    }
}
