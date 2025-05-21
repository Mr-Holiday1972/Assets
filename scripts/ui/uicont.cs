using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uicont : MonoBehaviour
{
    //�S��
    //変数宣言
    public int qqq;
    public datacontr DCRRef;
    public transition TRSRef;
    private bool rrrr;
    private string sss;
    private string ttt;
    public Vector2 newPosition;
    public bool uuu;
    public bool vvv;
    private float H;
    private float S;
    private float V;
    //private Renderer RDR;

    //���񂰂�[
    //キャンバス宣言
    public Behaviour title;
    public Behaviour mainmenue;
    public Behaviour gray;
    public Behaviour nosavedatabutton;
    public Behaviour worldcreate;
    public Behaviour singlescroll;
    public Behaviour worsettingscreen;
    public Behaviour ui;
    public Behaviour carselection;
    public Behaviour tuningcanv;
    public Behaviour maincarselection;
    public Behaviour gamemodecanv;
    public Behaviour paintjobcanv;

    //ボタン宣言
    public Button single;
    public Button multi;
    public Button task;
    public Button back;
    public Button nosavedatabuttonitsself;
    public Button createworldcancel;
    public Button gammeode;
    public Button vehicle;
    public Button traffics;
    public Button daylight;
    public Button worldsettings;
    public Button worsetdone;
    public Button mattype;
    public Button lapss;
    public Button opponent;
    public Button location;
    public Button tuning;
    public Button openworld;
    public Button race;
    public Button taxi;
    public Button timeattack;
    public Button backtomapset;
    public Button backtocarsel;
    public Button paintjobs;
    public Button backtocarsel2;

    //TMP宣言
    public TextMeshProUGUI GMT;
    public TextMeshProUGUI VT;
    public TextMeshProUGUI TT;
    public TextMeshProUGUI DT;
    public TextMeshProUGUI MTT;
    public TextMeshProUGUI LT;
    public TextMeshProUGUI ORT;
    public TextMeshProUGUI LST;

    //画像宣言
    public Image gear;
    public Image transition;
    public Image pjpc;//paint job product color

    //スクロール宣言
    public ScrollRect mainscroll;
    public ScrollRect tunescroll;

    //スライダー宣言
    public Slider HSlider, SSlider, VSlider;

    //�f�[�^����錾
    //ワールドセッティング宣言
    public string worldnamee;//default=new drive
    public int gamemodee;//race, openworld, mission, timeattack
    public int maptemplatee;//circuit�A���K���A���̐X�A�e�X�g�i�X�[�p�[�t���b�g�j�A���T�i�A���v���t�@�C�h�j�A���T�i�r��j
    public int cartypee;//challenger,crown,
    public float carxx;
    public float caryy;
    public float carzz;
    public int fuell;
    public int damagee;
    public int daycycc;//eg 0000-3600
    public bool trafficss;
    public int matchtype;
    public int laps;
    public int racers;

    // Start is called before the first frame update
    void Start()
    {
        laps = 2;
        racers = 8;
        newPosition = new Vector2 (870, 0);

        ui.enabled = true;
        carselection.enabled = false;

        //RDR = GetComponent<Renderer>();

        HSlider.maxValue = 1;
        SSlider.maxValue = 1;
        VSlider.maxValue = 1;
        HSlider.minValue = 0;
        SSlider.minValue = 0;
        VSlider.minValue = 0;

        //�֐��Ăяo����
        //ボタン宣言pt2
        back.onClick.AddListener(goback);
        single.onClick.AddListener(singlemenue);
        multi.onClick.AddListener(multimenue);
        task.onClick.AddListener(taskmenue);
        nosavedatabuttonitsself.onClick.AddListener(createsaves);
        createworldcancel.onClick.AddListener(createcancel);
        gammeode.onClick.AddListener(changegm);
        traffics.onClick.AddListener(changet);
        daylight.onClick.AddListener(changedl);
        worldsettings.onClick.AddListener(goworldsettings);
        worsetdone.onClick.AddListener(doneworldsettings);
        mattype.onClick.AddListener(changemattype);
        lapss.onClick.AddListener(changelaps);
        opponent.onClick.AddListener(changeopponent);
        location.onClick.AddListener(changelocation);
        tuning.onClick.AddListener(tunepres);
        openworld.onClick.AddListener(openworldpres);
        race.onClick.AddListener(racepres);
        taxi.onClick.AddListener(taxipres);
        timeattack.onClick.AddListener(timeattackpres);
        backtomapset.onClick.AddListener(backtomapsetting);
        backtocarsel.onClick.AddListener(backtocarselection);
        paintjobs.onClick.AddListener(paintjob);
        backtocarsel2.onClick.AddListener(backtocarselection);
    }

    // Update is called once per frame
    void Update()
    {
        rrrr = DCRRef.rrr;
        uuu = TRSRef.uuuu;

        //�C���v�b�g�`�F�\�b�N
        //キー検出
        if (Input.GetKey(KeyCode.Return) && qqq == 0)//==========
        {
            qqq = 1;
            mainscroll.verticalNormalizedPosition = 1.0f;
        }

        //�ϐ��`�F�\�b�N
        //変数適用内容
        if (qqq == 0)
        {
            //title
            mainmenue.enabled = false;
            title.enabled = true;
            gray.enabled = false;
            nosavedatabutton.enabled = false;
            worldcreate.enabled = true;
            singlescroll.enabled = false;
            worsettingscreen.enabled = false;
        }
        if (qqq == 1)
        {
            //gamemode
            mainmenue.enabled = true;
            title.enabled = false;
            gray.enabled = true;
            worldcreate.enabled = false;
            singlescroll.enabled = false;
            worsettingscreen.enabled = false;
            gamemodecanv.enabled = true;

            //if (rrrr)
            {
                nosavedatabutton.enabled = false;
            }
        }
        if (qqq == 10)
        {
            //savelist
            mainmenue.enabled = true;
            title.enabled = false;
            gray.enabled = true;
            worldcreate.enabled = false;
            singlescroll.enabled = true;
            worsettingscreen.enabled = false;
            gamemodecanv.enabled = false;

            //if (rrrr)
            {
                nosavedatabutton.enabled = true;
            }
        }
        if (qqq == 2)
        {
            //multi
            mainmenue.enabled = true;
            title.enabled = false;
            gray.enabled = true;
            nosavedatabutton.enabled = false;
            worldcreate.enabled = false;
            singlescroll.enabled = false;
            worsettingscreen.enabled = false;
        }
        if (qqq == 3)
        {
            //task
            mainmenue.enabled = true;
            title.enabled = false;
            gray.enabled = true;
            nosavedatabutton.enabled = false;
            worldcreate.enabled = false;
            singlescroll.enabled = false;
            worsettingscreen.enabled = false;
        }
        if (qqq == 4)
        {
            //cresave
            nosavedatabutton.enabled = false;
            worldcreate.enabled = true;
            singlescroll.enabled = false;
            worsettingscreen.enabled = false;
        }
        if (qqq == 5)
        {
            //wrdset
            nosavedatabutton.enabled = false;
            worldcreate.enabled = false;
            singlescroll.enabled = false;
            worsettingscreen.enabled = true;
        }
        if (qqq == 6)
        {
            //tune
            ui.enabled = false;
            tuningcanv.enabled = true;
            maincarselection.enabled = false;
        }
        if (qqq == 11)
        {
            //back to main car sel
            ui.enabled = false;
            tuningcanv.enabled = false;
            maincarselection.enabled = true;
            paintjobcanv.enabled = false;
        }
        if (qqq == 12)
        {
            //paint jobs
            ui.enabled = false;
            tuningcanv.enabled = false;
            maincarselection.enabled = false;
            paintjobcanv.enabled = true;
        }
        if (gamemodee == 0)
        {
            GMT.text = "Game mode : Match";
        }
        if (gamemodee == 1)
        {
            GMT.text = "Game mode : Open world";
        }
        if (gamemodee == 2)
        {
            GMT.text = "Game mode : Tasks";
        }
        if (gamemodee == 3)
        {
            GMT.text = "Game mode : Time attack";
        }
        if (matchtype == 0)
        {
            MTT.text = "Game mode : Classic";
        }
        if (matchtype == 1)
        {
            MTT.text = "Game mode : Clean";
        }
        if (matchtype == 2)
        {
            MTT.text = "Game mode : Drag race";
        }
        if (matchtype == 3)
        {
            MTT.text = "Game mode : VS";
        }
        if (maptemplatee == 0)
        {
            LST.text = "Location : Circuit";
        }
        if (maptemplatee == 1)
        {
            LST.text = "Location : Driving school";
        }
        if (maptemplatee == 2)
        {
            LST.text = "Location : Deep forrest";
        }
        if (maptemplatee == 3)
        {
            LST.text = "Location : Test(Super flat)";
        }
        if (maptemplatee == 4)
        {
            LST.text = "Location : Mesa";
        }
        if (maptemplatee == 5)
        {
            LST.text = "Location : Wastland";
        }
        if (maptemplatee == 6)
        {
            LST.text = "Location : City";
        }
        if (maptemplatee == 7)
        {
            LST.text = "Location : Shutoko";
        }

        //���̑����X
        //ワールドセッティングボタン系
        sss = laps.ToString();
        LT.text =  "Laps : " + sss;
        ttt = racers.ToString();
        ORT.text = "Opponent racers : " + ttt;

        if (gamemodee != 0)
        {
            worldsettings.interactable = false;
            gear.color = new Color32(149, 149, 149, 149);
        }
        else
        {
            worldsettings.interactable = true;
            gear.color = new Color32(255, 255, 255, 255);
        }
        if (gamemodee == 0)
        {
            traffics.interactable = false;
            TT.color = new Color32(149, 149, 149, 149);
        }
        else
        {
            traffics.interactable = true;
            TT.color = new Color32(255, 255, 255, 255);
        }

        if (uuu)
        {
            ui.enabled = false;
            carselection.enabled = true;
        }
        uuu = false;

        H = HSlider.value;
        S = SSlider.value;
        V = VSlider.value;
        //RDR.material.color = Color.HSVToRGB(H, S, V);
        pjpc.color = Color.HSVToRGB(H, S, V);
    }

    //�{�^���������ꂽ���̕ϐ��ύX
    //ボタン押された時の変数変更
    void goback()
    {
        if (qqq > 0)
        {
            qqq = 0;
        }
    }
    void singlemenue()
    {
        qqq = 1;
    }
    void multimenue()
    {
        qqq = 2;
    }
    void taskmenue()
    {
        qqq = 3;
    }
    void createsaves()
    {
        qqq = 4;
    }
    void createcancel()
    {
        qqq = 1;
    }
    void goworldsettings()
    {
        qqq = 5;
    }
    void doneworldsettings()
    {
        qqq = 4;
    }
    void tunepres()
    {
        qqq = 6;
        tunescroll.verticalNormalizedPosition = 1.0f;
    }
    void openworldpres()
    {
        qqq = 10;
    }
    void racepres()
    {
        qqq = 7;
    }
    void taxipres()
    {
        qqq = 8;

    }
    void timeattackpres()
    {
        qqq = 9;

    }
    void backtomapsetting()
    {
        qqq = 4;

    }
    void backtocarselection()
    {
        qqq = 11;

    }
    void paintjob()
    {
        qqq = 12;
    }

    //����{�^��
    //特殊ボタン
    void changegm()
    {
        if (gamemodee == 3)
        {
            gamemodee = 0;
        }
        else
        {
            gamemodee += 1;
        }
    }

    ///void MoveButtonToPosition(Vector2 position)
    //{
        // Get the RectTransform of the UI button.
    //    RectTransform buttonRectTransform = transition.GetComponent<RectTransform>();
        // Set the new position.
    //    buttonRectTransform.anchoredPosition = position;
    //}
    void changet()
    {
        //TT.text = "UI��ύX���܂���";
    }
    void changedl()
    {
        //DT.text = "UI��ύX���܂���";
    }
    void changemattype()
    {
        if (matchtype == 3)
        {
            matchtype = 0;
        }
        else
        {
            matchtype += 1;
        }
    }
    void changelaps()
    {
        if (laps == 64)
        {
            laps = 1;
        }
        else
        {
            laps *= 2;
        }
    }
    void changeopponent()
    {
        if (racers == 32)
        {
            racers = 0;
        }
        else if (racers != 0)
        {
            racers *= 2;
        }
        else
        {
            racers += 1;
        }
    }
    void changelocation()
    {
        if (maptemplatee == 7)
        {
            maptemplatee = 0;
        }
        else
        {
            maptemplatee += 1;
        }
    }
}

//今は解読不可の私のアイデア達（泣）（visual studioのバージョンめー）
//�A�C�f�A�F�V���b�v�ɍs���Ƃ��́A�O�ɂ����y�[�W�̐�����ۑ����ăV���b�v���o�����ɂ܂���������[�h����΂����񂶂�H���Ƃ́A����̃V���b�v�̃y�[�W�ɍs���Ƃ��͂��̐������w�肷��Δ�ׂ�B
//�N���[���Adrag race�Alap���Avs�A���C�o�����A�R�[�X�Aetc
//�ݒ�F�I�[�g�A�N�Z���i�I�[�g�X���b�g���j�A�����^�]�A���A�Փˌx�����A�~�j�}�b�v�A�O�փO���b�v�⏕�Aetc