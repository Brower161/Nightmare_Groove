using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    DoorScript door;

    private void Start()
    {
        door = FindObjectOfType<DoorScript>();
    }

    public void ActivarObjeto()
    {
        door.ActivarObjeto();
    }
}
