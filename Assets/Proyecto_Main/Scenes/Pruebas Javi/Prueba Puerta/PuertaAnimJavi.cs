using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAnimJavi : MonoBehaviour
{
    public Animator laPuerta;

    private void OnTriggerEnter(Collider other)
    {
        laPuerta.Play("PuertaAnim");
    }
}