using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downSound : MonoBehaviour
{
    private AudioSource shiftsound;
    public SimpleCarController SccRef;
    private bool hhhh;
    private bool iiii;

    void Start()
    {
        shiftsound = GetComponent<AudioSource>();
    }

    void Update()
    {
        hhhh = SccRef.hhh;
        iiii = SccRef.iii;

        if (hhhh || iiii)
        {
            shiftsound.PlayOneShot(shiftsound.clip);
        }
    }
}
