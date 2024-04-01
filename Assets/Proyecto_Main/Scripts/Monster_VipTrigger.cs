using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_VipTrigger : MonoBehaviour
{
    public Animator monsterScratchAnim;
    private bool animChecker = true;
    private bool destroyChecker = false;

    void Update()
    {
        if (destroyChecker)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && animChecker == true)
        {
            monsterScratchAnim.SetBool("canClose", true);
            animChecker = false;
        }
    }

    public void monsterGone()
    {
        destroyChecker = true;
    }
}
