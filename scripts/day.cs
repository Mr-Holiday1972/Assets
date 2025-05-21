using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day : MonoBehaviour
{
    public int hour;
    public int min;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogDensity = 0f;

        hour = 12;//����
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
            hour += 1;
        }

        if (hour == 24)
        {
            hour = 0;
        }
    }

    void addtime()
    {
        min += 1;

        if (hour == 19 && min < 52)
        {
            RenderSettings.fogDensity += 0.00025f;
        }

        if (hour == 5 && min < 52)
        {
            RenderSettings.fogDensity -= 0.00025f;
        }
    }
}
