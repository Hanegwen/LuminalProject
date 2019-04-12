using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FadeUIElement : MonoBehaviour
{
    //[Tooltip("UI Element must have a Canvas Group")]
    //public Behaviour UIElement;       //Must have a CanvasGroup

    public delegate void FadeEventHandler(object source, EventArgs e);

    public event FadeEventHandler FadeOutComplete;
    public event FadeEventHandler FadeInComplete;

    private CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        //cg = this.GetComponent<CanvasGroup>();

        //if (cg == null)
        //{
        //    Debug.Log("Warning: No CanvasGroup Found");
        //}

        ////FadeIn(0.0025f);
    }

    private void Awake()
    {
        cg = this.GetComponent<CanvasGroup>();

        if (cg == null)
        {
            Debug.Log("Warning: No CanvasGroup Found");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (cg.alpha <= 0f)
        //{
        //    FadeIn(0.0025f);
        //}
        //if (cg.alpha >= 1)
        //{
        //    FadeOut(0.0025f);
        //}

        //Debug.Log(cg.alpha);
    }

    public void FadeIn(float stepPerFrame)
    {
        StartCoroutine(FadeInCoroutine(stepPerFrame));
    }

    IEnumerator FadeInCoroutine(float stepPerFrame)
    {
        while (cg.alpha < 1)
        {
            cg.alpha += stepPerFrame;
            //Debug.Log("FadeIn" + cg.alpha);

            if (cg.alpha >= 1 - stepPerFrame
                && cg.alpha != 1)
            {
                cg.alpha = 1;
                //Debug.Log("FadeIn hit!");
                break;
            }

            yield return null;
        }

        cg.interactable = true;

        RaiseFadeInComplete();

        yield return null;
    }

    void RaiseFadeInComplete()
    {
        if (FadeInComplete != null)
        {
            FadeInComplete(this, null);
        }
    }

    public void FadeOut(float stepPerFrame)
    {
        StartCoroutine(FadeOutCoroutine(stepPerFrame));
    }

    IEnumerator FadeOutCoroutine(float stepPerFrame)
    {
        while (cg.alpha > 0)
        {
            //float a = Mathf.Lerp(0, 1, stepPerFrame);
            cg.alpha -= stepPerFrame;
            //Debug.Log(cg.alpha);

            //Debug.Log("Lerp Val: " + a);

            if (cg.alpha <= stepPerFrame
                && cg.alpha != 0)
            {
                cg.alpha = 0;
                //Debug.Log("hit!");
                break;
            }

            yield return null;
        }

        cg.interactable = false;

        RaiseFadeOutComplete();

        yield return null;
    }

    void RaiseFadeOutComplete()
    {
        if (FadeOutComplete != null)
        {
            FadeOutComplete(this, null);
        }
    }

}
