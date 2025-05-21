using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class metrecontrol : MonoBehaviour
{
    public float MaxSpeed = 0.0f;
    public float Speed = 0.0f;

    public Rigidbody rb;
    public Text text;
    public Image rdzn;//redzone
    public SimpleCarController SCCRef;
    private float alf;//alpha
    private bool vdw;//value difference wards
    public Image erpmndl;

    // Start is called before the first frame update
    void Start()
    {
        rdzn.color = new Color(100, 100, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if () �M�A�V�X�e�����ł�������r�ɓ����ĂȂ����velocity��ok�ɂ���i���������ȁH�������OnCollisionEnter�g���Ēn�ʂɂ��Ă���Ƃ���j

        //速度計関連
        Speed = rb.velocity.magnitude;
        text.text = $"{Speed.ToString("0")}";

        //レッドゾーン関連
        if ((SCCRef.erpm / (SCCRef.merpm - 1000)) > 1.0f)
        {
            rdzn.color = new Color(100, 100, 100, alf);
            if (vdw)
                alf -= Time.deltaTime * 5;
            else
                alf += Time.deltaTime * 5;

            if (alf < 0)
            {
                alf = 0;
                vdw = false;
            }
            else if (alf > 1)
            {
                alf = 1;
                vdw = true;
            }
        }
        else
        {
            rdzn.color = new Color(100, 100, 100, 0);
        }

        //回転速度計関連
        //erpmndl.transform.rotation = Quaternion.Euler(0f, 0f, );
        erpmndl.transform.eulerAngles = new Vector3(0f, 180f, ((SCCRef.erpm / 44.5f) + 135.5f));
    }
}