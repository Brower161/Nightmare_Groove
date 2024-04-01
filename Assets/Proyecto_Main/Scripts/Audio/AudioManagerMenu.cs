using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManagerMenu : MonoBehaviour
{

    private List<EventInstance> eventInstances;

    public static AudioManagerMenu instance { get; private set; }

    private void Awake()
    {
        //secure we only have one AudioManager on the scene
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
