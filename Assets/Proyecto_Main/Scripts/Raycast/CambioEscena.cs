using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambioEscena : MonoBehaviour
{
    DoorScript doorScript;
    DoorScript2 doorScript2;

    Animator animator;

    [SerializeField] private GameObject Cute;
    [SerializeField] private GameObject Terror;
    [SerializeField] public GameObject[] oldAssets;
    [SerializeField] public GameObject[] cartoonAssets;

    //public Material NormalMAT;
    //public Material OutlineMAT;

    public bool Activado;
    public float SegundosActivado = 2f;
    public float SegundosActivado2 = 10f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetBool("Activado", false);

        Cute.SetActive(false);
        Terror.SetActive(true);
        Activado = false;

        doorScript = FindObjectOfType<DoorScript>();
        doorScript2 = FindObjectOfType<DoorScript2>();
    }

    public void ActivarObjeto()
    {
        Cute.SetActive(true);
        Terror.SetActive(false);
        Activado = true;

        doorScript.ActivarObjeto();
        doorScript2.ActivarObjeto();

        //animator.SetBool("Activado", true);
        StartCoroutine(EsperarYDespuesEjecutar());
        StartCoroutine(EsperarYDespuesEjecutar2());


        Debug.Log("Se ha cambiado la estética");
    }

    //VOID ANIMACIÓN BOTÓN
    private IEnumerator EsperarYDespuesEjecutar()
    {
        yield return new WaitForSeconds(SegundosActivado);
        DesactivarObjeto();
    }
    public void DesactivarObjeto()
    {
        //animator.SetBool("Activado", false);
        //GetComponent<MeshRenderer>().material = NormalMAT;

        

        Debug.Log("Animación Puerta");
    }


    //VOID CAMBIO MAPA
    private IEnumerator EsperarYDespuesEjecutar2()
    {
        yield return new WaitForSeconds(SegundosActivado2);
        DesactivarObjeto2();
    }

    public void DesactivarObjeto2()
    {
        Cute.SetActive(false);
        Terror.SetActive(true);

        doorScript.DesactivarObjeto();
        doorScript2.DesactivarObjeto();

        Debug.Log("La estética ha vuelto a la normalidad");
    }
}
