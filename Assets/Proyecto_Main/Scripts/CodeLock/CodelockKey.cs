using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodelockKey : MonoBehaviour
{
    public string key;
    public bool canPress;
    public Animator keyAnimator;

    public void Start()
    {
       canPress = true;
    }
    public void SendKey()
    {
        if (canPress)
        {
            StartCoroutine(KeyCooldown());
        }
    }

    IEnumerator KeyCooldown()
    {
        canPress = false;
        keyAnimator.Play("PressKey");
        this.transform.GetComponentInParent<CodelockController>().PasswordEntry(key);
        yield return new WaitForSeconds(1);
        canPress = true;
        yield return null;
    }
}
