using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODEventsMenu : MonoBehaviour
{
    [field: Header("Enemies SFX")]
    [field: SerializeField] public EventReference ui_click { get; private set; }
    
    public static FMODEventsMenu instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}
