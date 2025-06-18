//sets the the daytime of the scene, and changes the fog density as it approaches the night.
//not linked with the day anim, but it has to be to look the best.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day : MonoBehaviour
{
    public int h;//hour
    public int min;//minute

    //
    void Start()
    {
        RenderSettings.fogDensity = 0f;

        h = 12;//����
        min = 00;
        //���Ԃ̕\�L�F
        //(0)000:�[��0��
        //(0)600:����
        //1200:����
        //1800:�[���
        //2400:�[��i�i���m�ɂ�2459���j0000�Ɠ��l�j

        InvokeRepeating("addtime", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (min == 60)
        {
            min = 0;
            h += 1;
        }

        if (h == 24)
        {
            h = 0;
        }
    }

    void addtime()
    {
        min += 1;

        if (h == 19 && min < 52)
        {
            RenderSettings.fogDensity += 0.00025f;
        }

        if (h == 5 && min < 52)
        {
            RenderSettings.fogDensity -= 0.00025f;
        }
    }
}