using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator PuertaFinal;
    private void OnTriggerEnter(Collider other)
    {
        PuertaFinal.Play("AnimPuertaFinal");
    }
}