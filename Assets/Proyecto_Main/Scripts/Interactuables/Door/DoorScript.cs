using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Abierto", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarObjeto()
    {
        anim.SetBool("Abierto", true);
    }

    public void DesactivarObjeto()
    {
        anim.SetBool("Abierto", false);
    }
}
