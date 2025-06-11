using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drivercam : MonoBehaviour
{
    [SerializeField]
    private int sensitivity;
    private float y_mouse;
    private float x_mouse;

    public Transform seat;//dcpov == driver-cam POV
    private Vector3 rot;//rotation
    private Vector3 apply;//well, apply... I mean it literally saids so right?
    public Behaviour pause;
    public SimpleCarController SCCRef;
    public bool imss;

    void Update()
    {
        imss = SCCRef.ims;

        rot = seat.localEulerAngles;

        //Input
        y_mouse = Input.GetAxisRaw("Mouse Y");
        x_mouse = Input.GetAxisRaw("Mouse X");
        
        //applying the sensitivity
        rot.x -= y_mouse * ((sensitivity / 100) * 0.1f);
        if (Input.GetKey(KeyCode.V))
        {
            rot.y += x_mouse * ((sensitivity / 100) * 0.8f);
        }
        else
        {
            rot.y += x_mouse * ((sensitivity / 100) * 0.1f);
        }
        if (imss && Input.GetKey(KeyCode.B))
        {
            rot.y = 0;
        }
        
        //setting the rotation
        seat.localEulerAngles = rot;
        apply = seat.eulerAngles;
        apply.x = rot.x;
        if (!pause.enabled){transform.localEulerAngles = apply;}

        //...and ofcourse position too.
        transform.position = seat.position;
    }
}