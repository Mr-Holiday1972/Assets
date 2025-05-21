using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLight : MonoBehaviour
{
    public Light headR;
    public Light headL;
    public Light haloR;
    public Light haloL;
    public Light lowR;
    public Light lowL;

    private bool beam;
    private bool switched;

    private AudioSource headlightsound;

    // Start is called before the first frame update
    void Start()
    {
        var headR = GetComponent<Light>();
        var headL = GetComponent<Light>();
        var haloR = GetComponent<Light>();
        var haloL = GetComponent<Light>();
        var lowR = GetComponent<Light>();
        var lowL = GetComponent<Light>();

        headlightsound = GetComponent<AudioSource>();
        //headR.enabled = false;

        beam = true;
        //true=>high, false=>low
        switched = false;
        //true=>on false=>oof
    }

    // Update is called once per frame
    void Update()
    {
        if (switched)
        {
            if (beam)
            {
                headR.enabled = true;
                headL.enabled = true;
                lowR.enabled = false;
                lowL.enabled = false;
            }
            else
            {
                lowR.enabled = true;
                lowL.enabled = true;
                headR.enabled = false;
                headL.enabled = false;
            }
        }
        else
        {
            headR.enabled = false;
            headL.enabled = false;
            lowR.enabled = false;
            lowL.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Return))//==========
        {
            switched = !switched;

            haloR.enabled = !haloR.enabled;
            haloL.enabled = !haloL.enabled;

            headlightsound.PlayOneShot(headlightsound.clip);
        }

        if (Input.GetKeyUp(KeyCode.RightShift))//==========
        {
            beam = !beam; 

            headlightsound.PlayOneShot(headlightsound.clip);
        }
    }
}
