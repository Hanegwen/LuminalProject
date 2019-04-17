using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    public AnimationCurve pointsMoveCurve;
    public AnimationCurve pointsFadeCurve;
    public AnimationCurve pointsSizeCurve;

    GameObject pointsText;
    ParticleSystem hitParticle;
    bool pointsAnimating = false;
    float pointsTime = 0;
    Camera playerCamera;
    Color[] colors = new Color[6];
    Color particleRed = new Color(0.972549f, 0.07843135f, 0.1041675f);
    Color particleOrange = new Color(0.972549f, 0.218721f, 0.07843135f);
    Color particleYellow = new Color(0.9150943f, 0.5217074f, 0.2374066f);
    Color particleGreen = new Color(0.124377f, 0.4056604f, 0.1370457f);
    Color particleBlue = new Color(0.1128961f, 0.459994f, 0.5566038f);
    Color particlePink = new Color(0.972549f, 0, 0.9037572f);

    private void Awake()
    {
        this.gameObject.transform.parent = null;
    }

    private void Start()
    {
        playerCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();

        pointsText = transform.GetChild(0).gameObject;
        hitParticle = transform.GetComponentInChildren<ParticleSystem>();

        colors[0] = particleRed;
        colors[1] = particleOrange;
        colors[2] = particleYellow;
        colors[3] = particleGreen;
        colors[4] = particleBlue;
        colors[5] = particlePink;

        int randNum = Mathf.RoundToInt(Random.Range(0, 6));
        ParticleSystem.MainModule pMain = hitParticle.main;
        pMain.startColor = colors[randNum];

        pointsAnimating = true;
        Destroy(gameObject, 1);
    }

    private void Update()
    {
        if (pointsAnimating)
        {
            pointsText.transform.localPosition = new Vector3(0, pointsMoveCurve.Evaluate(pointsTime), 0);
            pointsText.GetComponent<TextMeshPro>().color = new Color(pointsText.GetComponent<TextMeshPro>().color.r, 
                pointsText.GetComponent<TextMeshPro>().color.g, pointsText.GetComponent<TextMeshPro>().color.b, pointsFadeCurve.Evaluate(pointsTime));
            pointsText.GetComponent<TextMeshPro>().fontSize = pointsSizeCurve.Evaluate(pointsTime);
            pointsTime += Time.deltaTime;

            if (pointsTime > pointsFadeCurve.keys[pointsFadeCurve.length - 1].time)
            {
                pointsAnimating = false;
                pointsTime = 0;
            }
        }
    }

    private void LateUpdate()
    {
        pointsText.transform.LookAt(pointsText.transform.position + new Quaternion(0, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w)
            * Vector3.forward, playerCamera.transform.rotation * Vector3.up);
    }

    private void OnDestroy()
    {
        return;
    }
}
