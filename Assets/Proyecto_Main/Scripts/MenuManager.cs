using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class MenuManager : MonoBehaviour
{
    [SerializeField] float secondsToExit, secondsToStart;
    [SerializeField] GameObject Cartel_Exit;

    public Animator jumpscareAnimator;

    public GameObject titleObj;
    public GameObject playObj;
    public GameObject optionsObj;
    public GameObject exitObj;
    public GameObject backObj;
    public GameObject controlsObj;


    private void Awake()
    {
        jumpscareAnimator.SetBool("Start", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        jumpscareAnimator.SetBool("Start", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickStart()
    {
        StartCoroutine(WaitToStart());
        jumpscareAnimator.SetBool("Start", true);
        AudioManagerMenu.instance.PlayOneShot(FMODEventsMenu.instance.ui_click, this.transform.position);
    }

    public void clickOptions()
    {
        titleObj.SetActive(false);
        playObj.SetActive(false);
        optionsObj.SetActive(false);
        exitObj.SetActive(false);
        backObj.SetActive(true);
        controlsObj.SetActive(true);
        AudioManagerMenu.instance.PlayOneShot(FMODEventsMenu.instance.ui_click, this.transform.position);
    }

    public void clickExit()
    {
        StartCoroutine(WaitToExit());
        jumpscareAnimator.SetBool("Exit", true);
        AudioManagerMenu.instance.PlayOneShot(FMODEventsMenu.instance.ui_click, this.transform.position);
        //Cartel_Exit.SetActive(true);
    }

    public void clickBack()
    {
        titleObj.SetActive(true);
        playObj.SetActive(true);
        optionsObj.SetActive(true);
        exitObj.SetActive(true);
        backObj.SetActive(false);
        controlsObj.SetActive(false);
        AudioManagerMenu.instance.PlayOneShot(FMODEventsMenu.instance.ui_click, this.transform.position);
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(secondsToStart);
        jumpscareAnimator.SetBool("Start", false);
        SceneManager.LoadScene("ContractScene");
    }

    private IEnumerator WaitToExit()
    {
        yield return new WaitForSeconds(secondsToExit);
        Application.Quit();
        jumpscareAnimator.SetBool("Exit", false);
        Debug.Log("Has salido");
    }
}
