using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    //private Vector3 latestPos;
    private int ccc;
    private int eee;
    public trail TRLRef;
    private bool drifttt;
    // Start is called before the first frame update
    void Start()
    {
        //var particleSystem = GetComponent<ParticleSystem>();
        //var main = particleSystem.main;
        //main.startSize = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        drifttt = TRLRef.drift;
        //var direction = Vector3.forward;
        //Debug.Log(direction);

        //Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        //latestPos = transform.position;  //前回のPositionの更新
        //transform.rotation = Quaternion.LookRotation(diff); //向きを変更する

        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        float local_angle_x = localAngle.x;

        if (drifttt)
        {
            if (ccc <= 15)
            {
                ccc += 3;
            }
        }

        eee += 1;

        if (eee == 2)
        {
            LessSmoke();
            eee = 0;
        }
        

        var particleSystem = GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.rateOverTime = ccc;
    }

    void LessSmoke()
    {
        if (ccc != 0)
        {
            ccc -= 3;
        }
    }
}