using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Arbitro : MonoBehaviour
{
    [Header("Change Scene References")]
    [SerializeField] private GameObject CartoonDisco;
    [SerializeField] private GameObject BrokenDisco;

    [Header("Specific Event References")]
    public GameObject GramolaObj;
    public GameObject RadioObj;
    public GameObject DjObj;
    public GameObject FinalTriggerObj;

    public GameObject CartoonLight;
    public GameObject BrokenLight;
    public Animator CartoonLightAnim;
    public Animator BrokenLightAnim;
    
    [SerializeField] BrokenLight_Event brokenLightScript;
    [SerializeField] CartoonLight_Event cartoonLightScript;
    [SerializeField] JukeboxController gramolaScript;
    [SerializeField] RadioController radioScript;
    [SerializeField] DjController djScript;
    [SerializeField] FinalTriggerController finalTriggerScript;

    [Header("Event Bools")]
    private bool gramolaActivate;
    private bool stairsActivate;
    private bool radioActivate;
    private bool djActivate;
    private bool finalTriggerActivate;

    public bool Vinilo = false;
    public bool Casete = false;
    public bool Card = false;
    public bool djCheck = false;
    public bool dobleCheck = false;

    public bool lightEvent;
    public bool gramolaEvent;
    public bool radioEvent;
    public bool vipEvent;
    public bool triggerStairsEvent;
    public bool vipStairsEvent = false;

    [Header("Objects")]
    public GameObject ViniloObj;
    public GameObject CaseteObj;
    public GameObject monsterScratch;
    public GameObject monsterObj;

    //AUDIO
    bool gramolaMusicActivated;
    private EventInstance gramolaMusic;
    bool casetteMusicActivated;
    private EventInstance casetteMusic;
    bool djMusicActivated;
    private EventInstance djMusic;

    // Start is called before the first frame update
    void Start()
    {
        brokenLightScript = BrokenLight.GetComponent<BrokenLight_Event>();
        cartoonLightScript = CartoonLight.GetComponent<CartoonLight_Event>();
        gramolaScript = GramolaObj.GetComponent<JukeboxController>();
        radioScript = RadioObj.GetComponent<RadioController>();
        djScript = DjObj.GetComponent<DjController>();
        finalTriggerScript = FinalTriggerObj.GetComponent<FinalTriggerController>();

        Vinilo = false;
        Casete = false;
        Card = false;
        djCheck = false;
        gramolaActivate = false;
        radioActivate = false;
        djActivate = false;
        dobleCheck = false;

        CartoonDisco.SetActive(false);
        BrokenDisco.SetActive(true);

        //AUDIO
        gramolaMusicActivated = false;
        gramolaMusic = AudioManager.instance.CreateInstance(FMODEvents.instance.gramolaMusic);
        gramolaMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(GramolaObj.transform.position));

        casetteMusicActivated = false;
        casetteMusic = AudioManager.instance.CreateInstance(FMODEvents.instance.casetteMusic);
        casetteMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(RadioObj.transform.position));

        djMusicActivated = false;
        djMusic = AudioManager.instance.CreateInstance(FMODEvents.instance.djMusic);
    }

    void Update()
    {
        lightEvent = brokenLightScript.BrokenisFinished;
        triggerStairsEvent = cartoonLightScript.CartoonisFinished;
        gramolaEvent = gramolaScript.viniloTrue;
        radioEvent = radioScript.caseteTrue;
        djActivate = djScript.activeDj;
        finalTriggerActivate = finalTriggerScript.finalTriggerTrue;

        //EVENTO GRAMOLA
        if (gramolaEvent && gramolaActivate == false)
        {
            LightToCartoon();
            ViniloObj.SetActive(false);

            if (!gramolaMusicActivated) //to activate gramola music
            {
                gramolaMusicActivated = true;
                AudioManager.instance.gameplayMusic.setParameterByName("synthMusic", 1);
                gramolaMusic.start();
            }
        }

        if (lightEvent && gramolaActivate == false)
        {
            DiscoToCartoon();
            gramolaActivate = true;
        }

        //EVENTO ESCALERAS
        if (vipStairsEvent && stairsActivate == false)
        {
            LightToBroken();
            if (vipEvent == false)
            {
                monsterScratch.SetActive(true);
            }

            if (gramolaMusicActivated) //to stop gramola music
            {
                gramolaMusicActivated = false;
                AudioManager.instance.gameplayMusic.setParameterByName("synthMusic", 0);
                gramolaMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }

        //Debug.Log("triggersStairsEvent: " + triggerStairsEvent);

        if (triggerStairsEvent && stairsActivate == false)
        {
            DiscoToBroken();
            stairsActivate = true;
            vipStairsEvent = false;
        }

        if (triggerStairsEvent && dobleCheck == true)
        {
            DiscoToBroken();
            stairsActivate = true;
            vipStairsEvent = false;
            Destroy(monsterObj);
            AudioManager.instance.gameplayMusic.setParameterByName("synthMusic", 0);
            djMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        //EVENTO BOOMBOX
        if (radioEvent && radioActivate == false)
        {
            LightToCartoon();
            CaseteObj.SetActive(false);
            radioActivate = true;
            if (!casetteMusicActivated) // to activate casette music 
            {
                Debug.Log("activar musica");
                casetteMusicActivated = true;
                AudioManager.instance.gameplayMusic.setParameterByName("synthMusic", 1);
                casetteMusic.start();
            }
        }

        if (lightEvent && radioActivate == true)
        {
            DiscoToCartoon();
            vipToTrue();
            radioActivate = false;
        }

        if (djActivate && djCheck == false)
        {
            djCheck = true;
            LightToCartoon();
            monsterObj.SetActive(false);
            AudioManager.instance.gameplayMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            djMusic.start();
            Debug.Log("DJ music active");
        }

        if (finalTriggerActivate && dobleCheck == false)
        {
            dobleCheck = true;
            LightToBroken();
            Debug.Log("DJ music deactive");
        }

    }
    public void DiscoToCartoon()
    {
        //Debug.Log("prayforsatan");
        CartoonDisco.SetActive(true);
        BrokenDisco.SetActive(false);

        brokenLightScript.restoreBrokenLight();
    }

    public void DiscoToBroken()
    {
        CartoonDisco.SetActive(false);
        BrokenDisco.SetActive(true);

        cartoonLightScript.restoreCartoonLight();
    }

    public void LightToCartoon()
    {
        BrokenLightAnim.SetBool("ToCartoon", true);
    }

    public void LightToBroken()
    {
        CartoonLightAnim.SetBool("ToBroken", true);
    }

    public void vipToTrue()
    {
        vipEvent = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vipStairsEvent = true;
            stairsActivate = false;
            if (casetteMusicActivated) // to deactivate casette music
            {
                Debug.Log("desactivar musica");
                AudioManager.instance.gameplayMusic.setParameterByName("synthMusic", 0);
                casetteMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }



    //VINILO CONTROLLER
    public void ViniloFalse()
    {
        Vinilo = false;
    }

    public void ViniloTrue()
    {
        Vinilo = true;
        ViniloObj.SetActive(true);
    }

    //CASETE CONTROLLER
    public void CaseteFalse()
    {
        Casete = false;
    }

    public void CaseteTrue()
    {
        Casete = true;
        CaseteObj.SetActive(true);
    }

    //CARD CONTROLLER
    public void CardFalse()
    {
        Card = false;
    }

    public void CardTrue()
    {
        Card = true;
    }
}
