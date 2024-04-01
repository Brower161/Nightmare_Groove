using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoonLight_Event : MonoBehaviour
{
    public bool CartoonisFinished = false;
    public Animator CartoonLightAnim;


    public void CartoonFinish()
    {
        CartoonisFinished = true;
        CartoonLightAnim.SetBool("ToBroken", false);
    }

    public void CartoonFinishCheck()
    {
        CartoonisFinished = true;
        CartoonLightAnim.SetBool("ToBroken", false);
    }

    public void restoreCartoonLight()
    {
        CartoonisFinished = false;
    }
}
