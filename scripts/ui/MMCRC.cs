using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMCRC : MonoBehaviour//mini map cursor rotation cont
{
    public MMCC  MMCCref;
    private Vector3 a;
    private Vector3 bb;

    // Start is called before the first frame update
    void Start()
    {
        bb.y = 180;
    }

    // Update is called once per frame
    void Update()
    {
        a = MMCCref.aa;

        bb.z = a.y;

        this.transform.eulerAngles = bb;

    }
}
