using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodelockDoor : MonoBehaviour
{
    public bool lockedByPassword;

    public Animator anim;

    public void OpenClose()
    {
        if (lockedByPassword)
        {
            Debug.Log("Locked by password");
            return;
        }

        anim.SetTrigger("Door");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.Play("ClDoor_Close");
        }
    }
}
