using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBackstage2 : MonoBehaviour
{
    public Animator RailAnim;
    public Animator MonsterAnim;
    [SerializeField] private GameObject MonsterVanish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MonsterVanish.SetActive(true);
            RailAnim.SetBool("Stage2", true);
            RailAnim.enabled = true;
            MonsterAnim.Play("Monster_Grito");
        }
    }
}
