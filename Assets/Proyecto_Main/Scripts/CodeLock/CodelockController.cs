using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;
public class CodelockController : MonoBehaviour
{
    public CodelockDoor door;
    public string password;
    public int passwordLimit;
    public TMP_Text passwordText;
    public Animator lightAnimator;
    public Animator doorAnimator;
    public GameObject activateMonster;

    private void Start()
    {
        passwordText.text = "";
    }

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if (number == "Enter")
        {
            Enter();
            return;
        }

        int length = passwordText.text.ToString().Length;
        if (length < passwordLimit)
        {
            passwordText.text = passwordText.text + number;
        }
    }

    public void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        if (passwordText.text == password)
        {
            door.lockedByPassword = false;
            lightAnimator.SetBool("toGreen", true);
            doorAnimator.Play("ClDoor_Open");
            activateMonster.SetActive(true);

            /*if (audioSource != null)
            {
                audioSource.PlayOneShot(correctSound);
                //CaseteObj.SetActive(false);
            }*/
            AudioManager.instance.PlayOneShot(FMODEvents.instance.codelockOk, this.transform.position);
            AudioManager.instance.gameplayMusic.setParameterByName("persecucionMusic", 1);
            passwordText.color = Color.green;
            StartCoroutine(waitAndClear());
        }
        else
        {
            Debug.Log("Error codelock");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.codelockError, this.transform.position);
            lightAnimator.SetBool("toRed", true);

            passwordText.color = Color.red;
            StartCoroutine(waitAndClear());
        }
    }

    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }

    private void resetLight()
    {
        lightAnimator.SetBool("toRed", false);
        lightAnimator.SetBool("toGreen", false);
    }
}
