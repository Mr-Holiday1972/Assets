using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Worlddata
{
    public string worldname;//default=new drive
    public int gamemode;//race, openworld, mission, timeattack
    public int maptemplate;//circuit、教習所、松の森、テスト（スーパーフラット）、メサ（アンプリファイド）、メサ（荒野）
    public int cartype;//challenger,crown,
    public float carx;
    public float cary;
    public float carz;
    public int fuel;
    public int damage;
    public int daycyc;//eg 0000-3600
    public bool traffics;
}

public class datascont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Worlddata worlddata = new Worlddata();
        worlddata.worldname = "new drive";//ここを何かしらのインプットの文字列にあとで変える
        worlddata.gamemode = 1;//ここも何かしらのインプットで、ゲームモードを変える。（0=race 1=openworld...）
        worlddata.maptemplate = 0;//guess what!you do a same thing here!(0=circuit 1=教習所...)
        worlddata.cartype = 0;//same here too!
        worlddata.carx = 1.1f;//same here,
        worlddata.cary = 2.2f;//and here,
        worlddata.carz = 3.3f;//and here,
        worlddata.fuel = 1200;//and here,
        worlddata.damage = 0;//AaAAaaaAnd here,
        worlddata.daycyc = 0000;//here,
        worlddata.traffics = false;//ANDDDDD finally here! :)
        string jsonstr = JsonUtility.ToJson(worlddata);//ここでファイル作成

        Debug.Log(jsonstr);
        //string jsonData = JsonUtility.ToJson(worlddata);
        //System.IO.File.WriteAllText("MyWorld.json", jsonData);
        string jsonData = System.IO.File.ReadAllText("MyWorld.json");
        Worlddata loadedData = JsonUtility.FromJson<Worlddata>(jsonData);



        Worlddata worlddataa = loadPlayerData();//

        Debug.Log(worlddataa.worldname);
        Debug.Log(worlddataa.gamemode);
        Debug.Log(worlddataa.maptemplate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Worlddata loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/MyWorld.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Worlddata>(datastr);
    }
}
