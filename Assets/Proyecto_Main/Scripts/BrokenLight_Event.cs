using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLight_Event : MonoBehaviour
{
    public bool BrokenisFinished = false;
    public Animator BrokenLightAnim;

    public void BrookenFinish()
    {
        BrokenisFinished = true;
        BrokenLightAnim.SetBool("ToCartoon", false);
    }

    public void restoreBrokenLight()
    {
        BrokenisFinished = false;
    }
}
