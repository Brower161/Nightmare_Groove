using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxController : MonoBehaviour
{
    Arbitro arbitro;
    public Animator gramolaAnim;
    public bool viniloTrue = false;
    
    //[SerializeField]  GameObject[] oldAssets;

    void Start()
    {
        arbitro = FindObjectOfType<Arbitro>();
    }

    void Update()
    {
        
    }

    

    public void ActivarGramola()
    {
        gramolaAnim.SetBool("GramolaOn", true);
        Debug.Log("Has colocado el Vinilo;");
        viniloTrue = true;
    }

    public void Mensaje()
    {
        Debug.Log("No tienes el vinilo");
    }
}
