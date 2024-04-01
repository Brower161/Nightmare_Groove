using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class MonsterScript : MonoBehaviour
{
    /*public NavMeshAgent monsterAI;
    public float AIspeed;*/

    public Transform player;
    public bool stopRail;
    public Animator monsterAnim;
    public Rigidbody monsterRigi;
    //public Vector3 rayCastOffset;

    public CinemachineVirtualCamera playerCam, jumpscareCam;

    //Fmod
    EventInstance monsterScreamAudio;
    EventInstance monsterRawrAudio;
    EventInstance monsterStepAudio;

    void Start()
    {
        monsterStepAudio = AudioManager.instance.CreateInstance(FMODEvents.instance.monsterStep);
        monsterScreamAudio = AudioManager.instance.CreateInstance(FMODEvents.instance.monsterScream);
        monsterRawrAudio = AudioManager.instance.CreateInstance(FMODEvents.instance.monsterRawr);

        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(monsterStepAudio, GetComponent<Transform>(), GetComponent<Rigidbody>());
        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(monsterScreamAudio, GetComponent<Transform>(), GetComponent<Rigidbody>());
        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(monsterRawrAudio, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void Update()
    {
        monsterStepAudio.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        monsterScreamAudio.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        monsterRawrAudio.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(jumpscare());
        }
    }

    IEnumerator jumpscare()
    {
        //monsterAI.speed = 0;
        //AIspeed = 0;
        playerCam.Priority = (1);
        jumpscareCam.Priority = (2);
        //playerCam.enabled = false;
        monsterAnim.Play("Monster_Jumpscare");
        monsterRigi.velocity = new Vector3(0, 0, 0);
        yield return null;
        stopRail = true;
    }

    public void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void monsterScream()
    {
        monsterScreamAudio.start();
    }

    private void monsterWalk()
    {
        monsterStepAudio.start();
    }

    private void monsterJumpscare()
    {
        monsterRawrAudio.start();
    }
}
