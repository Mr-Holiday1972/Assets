using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverse : MonoBehaviour
{
    public SimpleCarController SCCRef;
    private int ffff;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ffff = SCCRef.fff;
        if (ffff == -1 && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        else if (ffff > -1)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
