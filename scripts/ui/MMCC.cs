using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMCC : MonoBehaviour//mini map cursor controller
{
    public Transform playercentre;
    private Vector3 yyy;
    private Vector3 zzz;
    public Vector3 aa;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zzz = playercentre.position;//プレイヤーの.position
        aa = playercentre.eulerAngles;

        yyy.x = zzz.x;
        yyy.z = zzz.z;
        yyy.y = zzz.y + 150f;//それぞれの座標を取得したやつ（zzz）から変数経由で（yyy）自身に設定
        this.transform.position = yyy;//設定
    }
}
