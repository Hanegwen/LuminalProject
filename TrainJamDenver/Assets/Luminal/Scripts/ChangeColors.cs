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

        ColorTransition(-22, 1, 0.7735f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ColorTransition(-22, 1, 0.7735f);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ColorTransition(50, 3, 0.7735f);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ColorTransition(70, 3, 0.9245f);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            ColorTransition(90, 4, 0.9245f);

    }

    public void ColorTransition(float CGSaturation, float BLIntensity, float pillarMatColor)
    {
        colorGradingLayer.saturation.value = CGSaturation;
        bloomLayer.intensity.value = BLIntensity;
        pillarMat.color = new Color(pillarMatColor, pillarMatColor, pillarMatColor);
    }
}
