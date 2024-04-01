using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Selected : MonoBehaviour
{
    //REFERENCIAS
    InteractableObject interactableObject;
    Arbitro arbitro;

    LayerMask mask;
    public float distancia = 1.5f;

    public Texture2D puntero;
    //public GameObject TextDetect;
    GameObject ultimoReconocido = null;

    public bool objetoVisible, interact;

    //MATERIALES
    public Material ShaderMAT;
    public Material NormalMAT;
    GameObject selectedObject;
   

    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        //TextDetect.SetActive(false);
        objetoVisible = true;

        arbitro = FindObjectOfType<Arbitro>();
    }

    
    void Update()
    {
        //Raycast(origen, dirección, out hit, distancia, mask)

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            if (selectedObject != null)
            {
                Deselect(hit.collider.gameObject);
            }
            SelectedObject(hit.collider.gameObject);

            if (hit.collider.tag == "DoorButton")
            {
                if (interact)
                {
                    hit.collider.transform.GetComponent<DoorButton>().ActivarObjeto();

                }

            }

            if (hit.collider.tag == "Card")
            {
                if (interact)
                {
                    hit.collider.transform.GetComponent<CardController>().ActivarObjeto();
                }

            }

            if (hit.collider.tag == "Vinilo")
            {
                if (interact)
                {
                    hit.collider.transform.GetComponent<ViniloController>().ActivarVinilo();
                }

            }

            if (hit.collider.tag == "Jukebox")
            {
                if (interact && arbitro.Vinilo == true)
                {
                    hit.collider.transform.GetComponent<JukeboxController>().ActivarGramola();

                    //hit.collider.transform.GetComponent<CambioEscena>().ActivarObjeto();

                    Debug.Log("Has accionado la Jukebox");
                }

                if (interact && arbitro.Vinilo == false)
                {
                    hit.collider.transform.GetComponent<JukeboxController>().Mensaje();
                }

            }

            if (hit.collider.tag == "CardDetect")
            {
                if (interact && arbitro.Card == true)
                {
                    hit.collider.transform.GetComponent<CardDetect>().ActivarObjeto();

                    hit.collider.transform.GetComponent<CambioEscena>().ActivarObjeto();

                    Debug.Log("Has accionado la Tarjeta");
                }

                if (interact && arbitro.Card == false)
                {
                    hit.collider.transform.GetComponent<CardDetect>().Mensaje();
                }

            }

            if (hit.collider.tag == "Radio")
            {
                if (interact && arbitro.Casete == true)
                {
                    hit.collider.transform.GetComponent<RadioController>().ActivarObjeto();
                }

                if (interact && arbitro.Casete == false)
                {
                    hit.collider.transform.GetComponent<RadioController>().Mensaje();
                }
            }

            if (hit.collider.tag == "Casete")
            {
                if (interact)
                {
                    hit.collider.transform.GetComponent<CaseteController>().ActivarObjeto();
                }
            }

            if (hit.collider.tag == "Button")
            {
                if (interact)
                {
                    hit.collider.transform.GetComponent<CodelockKey>().SendKey();
                }
            }

            if (hit.collider.tag == "Dj")
            {
                if (interact)
                {
                    hit.collider.transform.GetComponent<DjController>().ActivarObjeto();
                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            if (selectedObject != null)
            {
                Deselect(selectedObject);
            }
        }

    }

    void SelectedObject(GameObject hitObject)
    {
        NormalMAT = hitObject.GetComponent<MeshRenderer>().material;
        selectedObject = hitObject;
        hitObject.GetComponent<MeshRenderer>().material = ShaderMAT;
        
        ultimoReconocido = hitObject;
        
    }

    void Deselect(GameObject hitObject)
    {
        
        if (ultimoReconocido)
        {
            hitObject.GetComponent<MeshRenderer>().material = NormalMAT;
            selectedObject = null;
            ultimoReconocido = null;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        interact = context.ReadValueAsButton();
    }
}
