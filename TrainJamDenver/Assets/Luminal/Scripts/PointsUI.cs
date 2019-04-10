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

    private void Start()
    {
        pointsText = transform.GetChild(0).gameObject;
        hitParticle = transform.GetComponentInChildren<ParticleSystem>();

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
}
