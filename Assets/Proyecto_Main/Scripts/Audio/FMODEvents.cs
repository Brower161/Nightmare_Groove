using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Enemies SFX")]
    [field: SerializeField] public EventReference monsterStep { get; private set; }
    [field: SerializeField] public EventReference monsterScream { get; private set; }
    [field: SerializeField] public EventReference monsterRawr { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference casetteMusic { get; private set; }
    [field: SerializeField] public EventReference djMusic { get; private set; }
    [field: SerializeField] public EventReference gramolaMusic { get; private set; }
    [field: SerializeField] public EventReference gameplayMusic { get; private set; }
    //[field: SerializeField] public EventReference menuMusic { get; private set; }
    //[field: SerializeField] public EventReference allMusic { get; private set; }
    //[field: SerializeField] public EventReference bossMusic { get; private set; }

    [field: Header("Player SFX")]
    //[field: SerializeField] public EventReference playerFootsteps { get; private set; }
    //[field: SerializeField] public EventReference playerFootstepsRun { get; private set; }

    [field: Header("Props SFX")]
    //[field: SerializeField] public EventReference doorSlam { get; private set; }
    //[field: SerializeField] public EventReference lightSwitch { get; private set; }
    //[field: SerializeField] public EventReference gramola { get; private set; }
    //[field: SerializeField] public EventReference casette { get; private set; }
    //[field: SerializeField] public EventReference codelockBeep { get; private set; }
    [field: SerializeField] public EventReference codelockError { get; private set; }
    [field: SerializeField] public EventReference codelockOk { get; private set; }
    //[field: SerializeField] public EventReference casette { get; private set; }

    [field: Header("UI SFX")]
    //[field: SerializeField] public EventReference uiButtonClick { get; private set; }
    //[field: SerializeField] public EventReference uiButtonSelect { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}