using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    public Rigidbody carRB;
    public AudioSource Engine;
    public AudioSource Throttle;
    public AudioSource stutu;
    public AudioClip stutuclip;
    public AudioSource gg;//gear grinding, and unfortunately, it doesn't stand for good game. well, I'm not sure why now but, gg anyways!
    public AudioClip ggclip;
    public AudioSource dn;//driving noise

    public float minPitch;
    public float maxPitch;
    private float EnginePitch;
    private float ThrottlePitch;

    public SimpleCarController SCCRef;
    public metrecontrol MCRef;
    private int ffff;
    private bool hhhh;
    private bool iiii;
    private float jjj;
    private int kkk;
    private int nogg;
    private bool cee;
    public bool mrr;//max rev resonance
    private float thrtl;

    void Start()
    {
        Throttle.volume = 0f;
    }

    void Update()
    {
        ffff = SCCRef.fff;
        hhhh = SCCRef.hhh;
        nogg = SCCRef.nog;
        cee = SCCRef.ce;
        thrtl = SCCRef.thrtlv;

        if (hhhh)
        {
            Engine.pitch -= 0.2f;
            Throttle.pitch -= 0.2f; 
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (ffff < nogg && cee)
            {
                gg.PlayOneShot(ggclip);
            }
        }

        //ピッチ計算
        EnginePitch = (SCCRef.erpm / 5000);
        Engine.pitch = minPitch + EnginePitch;
        Throttle.pitch = minPitch + EnginePitch;

        if (thrtl < 50)
        {
            Throttle.volume = thrtl * 2;
        }
        
        stutu.volume = carRB.velocity.magnitude * 0.005f;

        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.W))//fix here!==============================
        {
            stutu.PlayOneShot(stutuclip);
        }

        if (MCRef.Speed > 8.0f && dn.volume < 1)
        {
            dn.volume += 0.01f;
        }
        else if(MCRef.Speed < 15.0f && dn.volume > 0)
        {
            dn.volume -= 0.01f;
        }
    }
}