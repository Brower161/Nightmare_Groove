using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicaTrigger : MonoBehaviour
{
    public GameObject PuertaCollider;
    public GameObject PuertaFinal;

    private void OnTriggerEnter(Collider other)
    {
        PuertaCollider.SetActive(true);
        PuertaFinal.SetActive(true);
    }
}
