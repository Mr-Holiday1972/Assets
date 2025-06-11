using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skiddingsound : MonoBehaviour
{
    private AudioSource carAudio;
    private float ooo;
    public trail TRLRef;
    private bool driftt;
    // Start is called before the first frame update
    void Start()
    {
        carAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        driftt = TRLRef.drift;
        if (driftt && ooo < 2)
        {
            ooo += 0.1f;
        }
        else if (ooo > 0)
        {
            ooo -= 0.1f;
        }

        //Debug.Log(driftt);

        carAudio.volume = ooo;
    }
}
