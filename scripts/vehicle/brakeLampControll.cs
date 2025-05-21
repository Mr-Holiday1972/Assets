using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brakeLampControll : MonoBehaviour
{
    public Light brakeR;
    public Light brakeL;
    // Start is called before the first frame update
    void Start()
    {
        var brakeR = GetComponent<Light>();
        var brakeL = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))//==========
        {
            brakeR.enabled = true;
            brakeL.enabled = true;
        }
        else
        {
            brakeR.enabled = false;
            brakeL.enabled = false;
        }
    }
}
