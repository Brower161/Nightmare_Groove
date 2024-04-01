using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vip1_DoorTrigger : MonoBehaviour
{
    public Animator doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorAnim.SetBool("canClose", true);
        }
    }
}
