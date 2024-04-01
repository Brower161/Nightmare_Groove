using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    Arbitro arbitro;

    public bool caseteTrue = false;

    // Start is called before the first frame update
    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivarObjeto()
    {
        Debug.Log("Has colocado el casete;");
        caseteTrue = true;
    }

    public void Mensaje()
    {
        Debug.Log("No tienes el casete");
    }
}
