using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumoScript : MonoBehaviour
{
    public Animator Humo;

    private void OnTriggerEnter(Collider other)
    {
        Humo.Play("HumoAnim");
    }
}
