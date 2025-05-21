using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[System.Serializable]
public class tstiptaxleee
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class tstinptctrl : MonoBehaviour//yes, "Simple"-Car-Controller. I know that. 
{
    [SerializeField]
    private InputActionReference _plyrctrl;
    public ctrl ctrl_;

    public float x;

    void Start()
    {
        ctrl_ = new ctrl();
        ctrl_.Enable();



        Application.targetFrameRate = 30;
    }

    private void OnEnable()
    {
        // ctrl_.Player.strgrst.performed += strgrst;
        // ctrl_.Player.strgrst.canceled += strgrst;

        _plyrctrl.action.performed += strg;
        _plyrctrl.action.canceled += strg;

        _plyrctrl.action.Enable();

        //ctrl_.Player.strg.performed += strg;
        //ctrl_.Player.strg.canceled += strg;
    }
    private void OnDisable()
    {
        // ctrl_.Player.strgrst.performed -= strgrst;
        // ctrl_.Player.strgrst.canceled -= strgrst;

        _plyrctrl.action.performed -= strg;
        _plyrctrl.action.canceled -= strg;

        _plyrctrl.action.Disable();
        
        //ctrl_.Player.strg.performed -= strg;
        //ctrl_.Player.strg.canceled -= strg;
    }


    public void strg(InputAction.CallbackContext value)
    {
        x = value.ReadValue<float>();
    }


    public void FixedUpdate()
    {
        Debug.Log(x);

        if (ctrl_.Player.thrtl.triggered)
        {
            Debug.Log(x);
        }
    }
}