using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MLC : MonoBehaviour // Mouse Lock Controller
{
    bool isLocked;
    private bool time;
    private bool cam;
    public Behaviour pause;
    public Behaviour controlsettings;
    public Behaviour settings;
    public AudioListener AL;
    public Drivercam DC; // Driver Cam
    public Cameracontroller BC; // Back Cam
    public SimpleCarController SCC; // Simple Car Controller
    public Button BTG; // Back to Game
    public Button CS; // Controller Settings
    public Button stngs; // Settings
    
    void Start()
    {
        time = true;
        cam = true;
        SetCursorLock(true);
        BTG.onClick.AddListener(backtogame);
        CS.onClick.AddListener(controlsetting);
        stngs.onClick.AddListener(setting);

        pause.enabled = true;
        pausing();
    }

    void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausing();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam = !cam;
        }

        if (time)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        if (time)
        {
            if (cam)
            {
                DC.enabled = true;
                BC.enabled = false;
            }
            else
            {
                DC.enabled = false;
                BC.enabled = true;
            }
        }
        else
        {
                DC.enabled = false;
                BC.enabled = false;
        }
    }

    void pausing()
    {
        if (pause.enabled == false)
        {
            SetCursorLock(false);
            pause.enabled = true;
            AL.enabled = false;
            SCC.enabled = false;
            time = false;
        }
        else
        {
            SetCursorLock(true);
            pause.enabled = false;
            AL.enabled = true;
            SCC.enabled = true;
            settings.enabled = false;
            controlsettings.enabled = false;
            time = true;
        }
    }

    void backtogame()
    {
        pausing();
    }

    void controlsetting()
    {
        pause.enabled = false;
        settings.enabled = false;
        controlsettings.enabled = true;
    }

    void setting()
    {
        pause.enabled = false;
        settings.enabled = true;
        controlsettings.enabled = false;
    }
}