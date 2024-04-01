using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjController : MonoBehaviour
{
    Arbitro arbitro;

    public bool activeDj = false;

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
        Debug.Log("Has activado la mesa de DJ");
        activeDj = true;
    }
}
