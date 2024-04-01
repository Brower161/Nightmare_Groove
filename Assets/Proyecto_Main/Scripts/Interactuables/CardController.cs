using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    Arbitro arbitro;

    // Start is called before the first frame update
    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>();
    }
    public void ActivarObjeto()
    {
        arbitro.CardTrue();
        Destroy(gameObject);
    }
}
