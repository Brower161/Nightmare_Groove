using System.Collections;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    
    [SerializeField] private GameObject cilindro;
    [SerializeField] private GameObject cilindro2;

    public bool Activado;
    public float SegundosActivado = 3f;

    private void Start()
    {
        cilindro.SetActive(false);
        cilindro2.SetActive(true);
        Activado = false;
    }

    public void ActivarObjeto()
    {
        cilindro.SetActive(true); 
        cilindro2.SetActive(false);
        StartCoroutine(EsperarYDespuesEjecutar());
        

    }

    private IEnumerator EsperarYDespuesEjecutar()
    {
        yield return new WaitForSeconds(SegundosActivado);
        DesactivarObjeto();
    }

    public void DesactivarObjeto()
    {
        cilindro.SetActive(false);
        cilindro2.SetActive(true);
    }

    

    

    
}
