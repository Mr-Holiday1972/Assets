using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWC : MonoBehaviour//steering wheel controller
{
    public float xxx;
    public Transform LF;
    public Vector3 newRotation;

    // Start is called before the first frame update
    void Start()
    {
        xxx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //xxx = LF.localRotation.y;
        if (LF.localRotation.eulerAngles.y <= 221 && LF.localRotation.eulerAngles.y >= 139)
        {
            xxx = LF.localRotation.eulerAngles.y;
        }
        else
        {
            xxx = LF.localRotation.eulerAngles.y - 180;
        }

        newRotation = this.transform.localRotation.eulerAngles;
        newRotation.z = xxx * 15;
        this.transform.localRotation = Quaternion.Euler(newRotation);
    }
}
