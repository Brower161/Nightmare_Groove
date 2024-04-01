using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumoScript2 : MonoBehaviour
{
    public Animator Humo2;

    private void OnTriggerEnter(Collider other)
    {
        Humo2.Play("HumoAnim2");
    }
}
