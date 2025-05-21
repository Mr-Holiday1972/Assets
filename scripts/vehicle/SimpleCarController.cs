using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[System.Serializable]
public class axleee
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class SimpleCarController : MonoBehaviour//yes, "Simple"-Car-Controller. I know that. 
{
    //input system系統
    [SerializeField]
    public InputActionReference _strg;
    public InputActionReference _thrtl;
    public InputActionReference _brk;
    public InputActionReference _clch;
    public ctrl ctrl_;

    public List<axleee> axleInfos;
    public List<float> gearInfos;//the 0th value is the reverse!
    public List<float> powerCurveInfos;//the number on the value (*1000) represents the each rpm on the power curve of the engine.
    public float MotorTorque;
    public float maxSteeringAngle;
    public float breakTorque;

    private Vector3 posA;

    //����UI�X�V�p�ϐ�
    public Text textt;
    public int fff;//current gear
    public float ggg;
    public Rigidbody rb;
    public bool hhh;
    public bool iii;

    float motor;
    public float vel;
    public bool wards;
    public float steering;
    public int wheelsensitivity;
    public Toggle mousesteer; 
    private float pbtrq;//parking brake torque
    public Vector3 com;//.com is now apparently .centre-of-mass
    public float erpm;//engine rpm
    private bool pb; //parking brake
    public bool ims;//is mouse steering
    public bool ce;//clutchengaged
    public int ag;//apply the gear
    public float torque;//torque
    public int nog;//number of gears
    public float rr;//rotation resistance
    public float wrpm;//wheel rpm
    public float rmxl;//rev max limit
    public float rmnl;//rev min limit
    public bool erpmr;//engine rpm ristricted(?)
    public float thrtlv;//throttle in 0-1
    public int intthrtl;//exact throtttle in 0-100
    public int merpm;//max erpm 
    private int uerpm;//upper erpm
    private int lerpm;//lower erpm
    private float cgr;//current gear ratios
    private float uerpmv;//upper erpm value
    private float lerpmv;//lower erpm value
    public int mwv;//mouse wheel value 
    public float strgv;//strg value
    public bool kbd;//key board
    public float mthrtlpv;//previous thrtlv
    public int strgi;//strg input
    public int clchv;

    void Start()
    {
        ctrl_ = new ctrl();
        ctrl_.Enable();

        fff = 1;
        ggg = 74;
        textt.text = "1";
        breakTorque = 0;
        pb = false;
        pbtrq = 8000;
        ims = false;
        nog = gearInfos.Count;
        rb.centerOfMass = com;
        erpm = 1000;
        torque = 185;
        merpm = 7000;

        mousesteer.onValueChanged.AddListener(delegate {
            ToggleValueChanged();
        });

        Application.targetFrameRate = 30;
    }

    private void OnEnable()
    {
        _strg.action.performed += strg;
        _strg.action.canceled += strg;

        _thrtl.action.performed += thrtl;
        _thrtl.action.canceled += thrtl;

        _brk.action.performed += brk;
        _brk.action.canceled += brk;

        _clch.action.performed += clch;
        _clch.action.canceled += clch;

        _strg.action.Enable();
        _thrtl.action.Enable();
        _brk.action.Enable();
        _clch.action.Enable();
    }
    private void OnDisable()
    {
        _strg.action.performed -= strg;
        _strg.action.canceled -= strg;

        _thrtl.action.performed -= thrtl;
        _thrtl.action.canceled -= thrtl;

        _brk.action.performed -= brk;
        _brk.action.canceled -= brk;

        _clch.action.performed -= clch;
        _clch.action.canceled -= clch;

        _strg.action.Disable();
        _thrtl.action.Disable();
        _brk.action.Disable();
        _clch.action.Disable();
    }

    // �Ή����鎋�o�I�ȃz�C�[���������܂�
    // Transform �𐳂����K�p���܂�
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        //�O�㌟�o
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        if (localVelocity.z > 0)
        {
            wards = true;
        }
        else
        {
            wards = false; 
        }

        if (ctrl_.Player.rst.triggered)//==========
        {
            
        }

        if (pb)
        {
            if (wards)
            {
                //motor = pbtrq * -1;
            }
            else
            {
                //motor = pbtrq;
            }
        }
        
        if (ims)
        {
            if (ctrl_.Player.strgrst.triggered)
            {
                steering = 0.0f;
            }
            else
            {
                steering += ((Input.GetAxisRaw("Mouse X") * (this.wheelsensitivity * 0.01f)));
                steering = Mathf.Clamp(steering, maxSteeringAngle * -1, maxSteeringAngle);
            }
        }
        else if (kbd)
        {
            if (strgi < 100 && strgi > -100 && !(strgv == 0))
            {
                strgi += (wheelsensitivity/ 10) * (int)strgv;
            }
            else
            {
                if (strgi > 0)
                {
                    strgi -= (wheelsensitivity / 10);
                }
                if (strgi < 0)
                {
                    strgi += (wheelsensitivity / 10);
                }
                
            }

            steering = maxSteeringAngle * (strgi * 0.01f);
        }
        else
        {
            steering = maxSteeringAngle * strgv;
        }
        
        foreach (axleee axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                wrpm = axleInfo.rightWheel.rpm;
            }

            if (pb)
            {
                if (axleInfo.motor)
                {
                    WheelFrictionCurve mpbForwardFriction = axleInfo.leftWheel.forwardFriction;
                    WheelFrictionCurve mpbSidewaysFriction = axleInfo.leftWheel.sidewaysFriction;

                    mpbForwardFriction.extremumSlip = 0.05f;
                    mpbForwardFriction.extremumValue = 1.8f;
                    mpbForwardFriction.asymptoteSlip = 0.2f;
                    mpbForwardFriction.asymptoteValue = 1.85f;

                    mpbSidewaysFriction.extremumSlip = 0.08f;
                    mpbSidewaysFriction.extremumValue = 0.3f;
                    mpbSidewaysFriction.asymptoteSlip = 0.38f;
                    mpbSidewaysFriction.asymptoteValue = 1.2f;
                    
                    axleInfo.leftWheel.forwardFriction = mpbForwardFriction;
                    axleInfo.rightWheel.forwardFriction = mpbForwardFriction;
                    axleInfo.leftWheel.sidewaysFriction = mpbSidewaysFriction;
                    axleInfo.rightWheel.sidewaysFriction = mpbSidewaysFriction;
                }
                else if (axleInfo.steering)
                {
                    WheelFrictionCurve spbSidewaysFriction = axleInfo.leftWheel.sidewaysFriction;

                    spbSidewaysFriction.extremumValue = 0.8f;
                    spbSidewaysFriction.asymptoteValue = 0.75f;
                    
                    axleInfo.leftWheel.sidewaysFriction = spbSidewaysFriction;
                    axleInfo.rightWheel.sidewaysFriction = spbSidewaysFriction;
                }
            }
            else
            {
                if (axleInfo.motor)
                {
                    WheelFrictionCurve mForwardFriction = axleInfo.leftWheel.forwardFriction;
                    WheelFrictionCurve mSidewaysFriction = axleInfo.leftWheel.sidewaysFriction;
                    
                    mForwardFriction.extremumSlip = 0.2f;
                    mForwardFriction.extremumValue = 1.4f;
                    mForwardFriction.asymptoteSlip = 0.6f;
                    mForwardFriction.asymptoteValue = 1.45f;

                    mSidewaysFriction.extremumSlip = 0.18f;
                    mSidewaysFriction.extremumValue = 1.8f;
                    mSidewaysFriction.asymptoteSlip = 0.6f;
                    mSidewaysFriction.asymptoteValue = 1.4f;
                    
                    axleInfo.leftWheel.forwardFriction = mForwardFriction;
                    axleInfo.rightWheel.forwardFriction = mForwardFriction;
                    axleInfo.leftWheel.sidewaysFriction = mSidewaysFriction;
                    axleInfo.rightWheel.sidewaysFriction = mSidewaysFriction;
                }
                else if (axleInfo.steering)
                {
                    WheelFrictionCurve sSidewaysFriction = axleInfo.leftWheel.sidewaysFriction;

                    sSidewaysFriction.extremumValue = 1.6f;
                    sSidewaysFriction.asymptoteValue = 1.3f;
                    
                    axleInfo.leftWheel.sidewaysFriction = sSidewaysFriction;
                    axleInfo.rightWheel.sidewaysFriction = sSidewaysFriction;
                }
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

        if (clchv > 0)
        {
            ce = false;
        }
        else
        {
            ce = true;
        }
        
        mwv = (int)(Input.GetAxis("Mouse ScrollWheel") * 100.0f);//==========

        hhh = false;
        iii = false;

        rb.centerOfMass = com;

        cgr = GetNthValue(gearInfos, fff);

        //シフトアップ
        if (ctrl_.Player.shftup.triggered && fff < (nog - 1))
        {
            if (ce)
            {
                ag = Random.Range(0, 10);

                if (fff == 0)
                {
                    if (rb.velocity.magnitude < 3)
                    {
                        fff += 1;
                    }
                }
                else
                {
                    fff += 1;
                }
            }
            else
            {
                if (fff == 0 && rb.velocity.magnitude < 3)//I'm not trying to express a heart here.
                {
                    fff += 1;
                }
                else if (fff != 0)
                {
                    fff += 1;
                }
            }
        }

        //シフトダウン
        if (ctrl_.Player.shftdwn.triggered && fff > 0)
        {
            if (ce)
            {
                ag = Random.Range(0, 10);

                if (ag == 1)
                {
                    if (fff == 1)
                    {
                        if (rb.velocity.magnitude < 3)
                        {
                            fff -= 1;
                        }
                    }
                    else
                    {
                        fff -= 1;
                    }
                }
            }
            else
            {
                if (fff == 1 && rb.velocity.magnitude < 3)
                {
                    fff -= 1;
                }
                else if (fff != 1)
                {
                    fff -= 1;
                }
            }
        }



        

        //出力計算
        //throttle計算
        if (kbd)
        {
            if (Input.GetKey(KeyCode.W) && intthrtl <= 90)//==========
            {
                intthrtl += 30;
            }
            else if (!Input.GetKey(KeyCode.W) && intthrtl >= 20)
            {
                intthrtl -= 30;
            }

            /*
            if ((intthrtl + mwv) <= 100 && (intthrtl + mwv) >= 0)
            {
                intthrtl += mwv;
            }
            /*/
        }
        thrtlv = intthrtl * 0.01f;

        //erpm resistance計算
        rmxl = (wrpm * 5) + (cgr * 25);
        rmnl = (wrpm * 5) - (cgr * 25);
        if (erpm > rmnl && erpm < rmxl)
        {
            erpmr = false;
        }
        else
        {
            //erpmr = true;//試験的段階
        }

        //erpm計算
        mthrtlpv = ((merpm - 1000) * thrtlv) + 1000;

        if (erpm < mthrtlpv && erpm < merpm)
        {
            if (!ce)
            {
                erpm += (rr * 10.0f) * thrtlv;
            }
            {
                if (!erpmr)
                {
                    erpm += (rr * cgr) * thrtlv;
                }
                else if (erpm > rmxl)
                {
                    erpm += ((rr * cgr) * (thrtlv * 0.5f));
                }
                else if (erpm < rmnl)
                {
                    erpm += ((rr * cgr) * (thrtlv * 2f));
                }
            }
        }
        else if (erpm > mthrtlpv && erpm > 1000)
        {
            if (!ce)
            {
                erpm -= rr * 5.0f;//ここは後でrrをクラッチがつながれていない時にwrpmを引いたりして減らすようにする
            }
            else
            {
                erpm -= (rr * cgr) * 0.8f;
            }
        }

        //パワーカーブ関連
        lerpm = Mathf.FloorToInt(erpm / 1000);//1200 => 1.2 => 1(000)erpm~
        uerpm = lerpm + 1;//1 + 1 = ~2(000)erpm
        lerpmv = GetNthValue(powerCurveInfos, lerpm);
        uerpmv = GetNthValue(powerCurveInfos, uerpm);

        //Motor torque計算(Nmを算出しようにもUnityの場合だとパワーではなく馬力なので...)
        MotorTorque = ((((6.28f * torque * erpm) / 60000) * cgr) * (lerpmv + ((uerpmv - lerpmv) * ((erpm % 1000) / 1000)))) * 25; //kW = 2pi * Nm * rpm / (60 * 1000) => Vehicle's power = (kW * gear ratio) * powercurve * 25(for an actual value, becasue unity only applies a portion of a real-life torque)
        //torque = (MotorTorque * 60 * 1000 / (6.28f * erpm)) * GetNthValue(gearInfos, fff); //Nm = kW * 60 * 1000 / (2pi * rpm) => (it's a bit of stretch here, but) Vehicle's power = Nm * gear ratio

        //motor適用
        if (breakTorque > 0)//==========
        {
            if (wards)
            {
                if (rb.velocity.magnitude < 3)
                {
                    motor = breakTorque * -0.1f;
                }
                else
                {
                    motor = breakTorque * -1;
                }
            }
            else
            {
                if (rb.velocity.magnitude < 3)
                {
                    motor = breakTorque * 0.1f;
                }
                else
                {
                    motor = breakTorque;
                }
            }
        }
        else if (fff == 0)
        {
            motor = MotorTorque * -1;
        }
        else if (!ce)
        {
            motor = 0;
        }
        else
        {
            motor = MotorTorque;
        }
        
        //iii = true;
        
        if (!ce)
        {
            textt.text = "N";
        }
        else if (fff == 0)
        {
            textt.text = "R";
        }
        else
        {
            textt.text = $"{fff.ToString("0")}";
        }

        vel = rb.velocity.magnitude;
        
        if (ctrl_.Player.prkbrk.triggered)
        {
            pb = !pb;
        }
    }

    void ToggleValueChanged()
    {
        ims = !ims;
    }

    float GetNthValue(List<float> list, int fff)
    {
        if (fff >= 0 && fff < list.Count)
        {
            return list[fff];
        }
        else
        {
            Debug.LogError("Index out of range");
            return -1.0f;
        }
    }

    public void strg(InputAction.CallbackContext value)
    {
        strgv = value.ReadValue<float>();
    }
    public void thrtl(InputAction.CallbackContext value)
    {
        intthrtl = Mathf.FloorToInt(value.ReadValue<float>() * 100.0f);
    }
    public void brk(InputAction.CallbackContext value)
    {
        breakTorque = 160 * Mathf.FloorToInt(value.ReadValue<float>() * 100.0f);
    }
    public void clch(InputAction.CallbackContext value)
    {
        clchv = Mathf.FloorToInt(value.ReadValue<float>());
    }
}