using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDetect : MonoBehaviour
{
    Arbitro arbitro;
    //DoorScript doorScript;
    //DoorScript2 doorScript2;

    // Start is called before the first frame update
    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>();
        //doorScript = FindObjectOfType<DoorScript>();
        //doorScript2 = FindObjectOfType<DoorScript2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarObjeto()
    {
        //doorScript.ActivarObjeto();
        //doorScript2.ActivarObjeto();
        //arbitro.ViniloFalse();
        Debug.Log("Has pasado la tarjeta;");
               
    }

    public void Mensaje()
    {
        Debug.Log("No tienes la tarjeta");
    }
}
