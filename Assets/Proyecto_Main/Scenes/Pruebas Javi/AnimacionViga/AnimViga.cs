using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimViga : MonoBehaviour
{

    public Animator Viga;

    private void OnTriggerEnter(Collider other)
    {
        Viga.Play("AnimationViga");
    }
}