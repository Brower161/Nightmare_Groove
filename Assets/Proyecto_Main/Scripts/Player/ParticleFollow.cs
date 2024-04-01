using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("NewPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
