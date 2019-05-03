using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnParticle : MonoBehaviour
{
    Color[] colors = new Color[6];
    Color particleRed = new Color(0.972549f, 0.07843135f, 0.1041675f);
    Color particleOrange = new Color(0.972549f, 0.218721f, 0.07843135f);
    Color particleYellow = new Color(0.9150943f, 0.5217074f, 0.2374066f);
    Color particleGreen = new Color(0.124377f, 0.4056604f, 0.1370457f);
    Color particleBlue = new Color(0.1128961f, 0.459994f, 0.5566038f);
    Color particlePink = new Color(0.972549f, 0, 0.9037572f);

    private void Start()
    {
        colors[0] = particleRed;
        colors[1] = particleOrange;
        colors[2] = particleYellow;
        colors[3] = particleGreen;
        colors[4] = particleBlue;
        colors[5] = particlePink;

        int randNum = Mathf.RoundToInt(Random.Range(0, 6));
        ParticleSystem.MainModule pMain = GetComponent<ParticleSystem>().main;
        pMain.startColor = colors[randNum];

        Destroy(gameObject, 1);
    }
}
