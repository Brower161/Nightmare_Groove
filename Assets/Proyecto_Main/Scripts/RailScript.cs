using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RailScript : MonoBehaviour
{
    [SerializeField] MonsterScript MonsterScript;
    public Animator railAnimator;
    public GameObject MonsterObj;

    // Start is called before the first frame update
    void Start()
    {
        MonsterScript = MonsterObj.GetComponent<MonsterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("monsterAnim" + MonsterScript.stopRail);

        if (MonsterScript.stopRail)
        {
            railAnimator.enabled = false;
        }
    }

    void StopAnim()
    {
        railAnimator.enabled = false;
    }
}
