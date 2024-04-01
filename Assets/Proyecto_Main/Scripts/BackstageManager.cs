using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstageManager : MonoBehaviour
{
    [SerializeField] private GameObject MonsterVanish;
    public Animator MonsterAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            MonsterAnim.SetBool("Stage2", true);
        }
    }
}
