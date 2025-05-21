using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    public uicont UCRef;
    public bool uuuu;
    private bool vvvv;
    public Button vehicle;
    public Behaviour black;
    public Behaviour ui;
    public Behaviour carselection;
    public Button backtoprevset;
    public Behaviour maincarsel;
    private Animator anim;
    public Behaviour paintjobcanv;
    public Behaviour tunecanv;
    private void Start()
    {
        vehicle.onClick.AddListener(changev);
        backtoprevset.onClick.AddListener(backtomapsettings);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //uuuu = UCRef.uuu;
        //vvvv = UCRef.vvv;
        //if (vvvv)
        {
            //black.enabled = false;
            //GetComponent<Animator>().SetTrigger("slideout");
        }
        //Debug.Log(vvvv);
    }
    private void changev()
    {
        anim.SetBool("slidein", true);
        //var animator = GetComponent<Animator>();
        //animator.SetTrigger("slidein");
        //Debug.Log("a");
        Invoke("showblack", 2);
    }
    private void backtomapsettings()
    {
        anim.SetBool("slidein", true);
        //var animator = GetComponent<Animator>();
        //animator.SetTrigger("slidein");
        //Debug.Log("a");
        Invoke("showblack2", 2);
    }
    private void showblack()
    {
        ui.enabled = false;
        carselection.enabled = true;
        maincarsel.enabled = true;
        paintjobcanv.enabled = false;
        tunecanv.enabled = false;
        //uuuu = true;
        //black.enabled = true;
        //GetComponent<Animator>().SetTrigger("slideout");
        //Debug.Log("b");
        anim.SetBool("slidein", false);
    }
    private void showblack2()
    {
        ui.enabled = true;
        carselection.enabled = false;
        maincarsel.enabled = false;
        anim.SetBool("slidein", false);
    }
}