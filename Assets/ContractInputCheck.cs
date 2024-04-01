using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContractInputCheck : MonoBehaviour
{
    private bool interact;
    public Animator fadeAnim;

    void Update()
    {
        if (interact)
        {
            fadeAnim.Play("FadeIn");
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        interact = context.ReadValueAsButton();
    }
}
