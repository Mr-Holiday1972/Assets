using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : MonoBehaviour
{
    private AudioSource hornsound;

    void Start()
    {
        hornsound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//==========
        {
            hornsound.PlayOneShot(hornsound.clip);
        }
    }
}