using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartel : MonoBehaviour
{
    public Animator CartelAnim;

    private void OnTriggerEnter(Collider other)
    {
        CartelAnim.Play("Cartel");
    }
}
