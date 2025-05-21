using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLight1 : MonoBehaviour
{
    public Light headR;
    public Light headL;
    // Start is called before the first frame update
    void Start()
    {
        var headR = GetComponent<Light>();
        var headL = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))//==========
        {
            headR.enabled = !headR.enabled;
            headL.enabled = !headL.enabled;
        }
    }
}
