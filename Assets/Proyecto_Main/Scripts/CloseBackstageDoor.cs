using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBackstageDoor : MonoBehaviour
{
    public Animator backStageDoor;
    public GameObject doorCollider;

    private void Start()
    {
        //backStageDoor = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Backdoor se cierra");
            backStageDoor.SetTrigger("closeDoor");
        }
    }

    public void closedDoor()
    {
        backStageDoor.enabled = false;
    }

    public void activateCollider()
    {
        doorCollider.SetActive(true);
    }
}
