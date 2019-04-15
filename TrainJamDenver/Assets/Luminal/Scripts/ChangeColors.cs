using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeColors : MonoBehaviour
{
    public PostProcessVolume volume;
    public Material pillarMat;

    ColorGrading colorGradingLayer;
    Bloom bloomLayer;

    private void Start()
    {
        volume.profile.TryGetSettings(out colorGradingLayer);
        volume.profile.TryGetSettings(out bloomLayer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ColorTransition(-22, 1);
            pillarMat.color = new Color(0.7735f, 0.7735f, 0.7735f, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ColorTransition(50, 3);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ColorTransition(70, 3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ColorTransition(90, 4);
            pillarMat.color = new Color(0.9245f, 0.9245f, 0.9245f, 1);
        }

    }

    public void ColorTransition(float CGSaturation, float BLIntensity)
    {
        colorGradingLayer.saturation.value = CGSaturation;
        bloomLayer.intensity.value = BLIntensity;
    }
}
