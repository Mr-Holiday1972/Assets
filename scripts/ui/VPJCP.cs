using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VPJCP : MonoBehaviour// vehicle paint jobs color picker
{
    float H;
    float S;
    float V;
    //These are the Sliders that control the values. Remember to attach them in the Inspector window.
    public Slider HSlider, SSlider, VSlider;

    //Make sure your GameObject has a Renderer component in the Inspector window
    Renderer RDR;

    void Start()
    {
        //Fetch the Renderer component from the GameObject with this script attached
        RDR = GetComponent<Renderer>();

        //Set the maximum and minimum values for the Sliders
        HSlider.maxValue = 1;
        SSlider.maxValue = 1;
        VSlider.maxValue = 1;

        HSlider.minValue = 0;
        SSlider.minValue = 0;
        VSlider.minValue = 0;
    }

    void Update()
    {
        //These are the Sliders that determine the amount of the hue, saturation and value in the Color
        H = HSlider.value;
        S = SSlider.value;
        V = VSlider.value;

        //Create an RGB color from the HSV values from the Sliders
        //Change the Color of your GameObject to the new Color
        RDR.material.color = Color.HSVToRGB(H, S, V);
    }
}

//Create three Sliders ( Create>UI>Slider)
//These are for manipulating the hue, saturation and value levels of the Color.

//Attach this script to a GameObject. Make sure it has a Renderer component.
//Click on the GameObject and attach each of the Sliders and Texts to the fields in the Inspector.