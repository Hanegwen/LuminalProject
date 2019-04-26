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
    Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = FindObjectOfType<Bullet>();
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

    }

    public void FadeIn(float stepPerFrame)
    {
        //bullet.GetComponent<BoxCollider>().enabled = false;
        print("Fade");
        StartCoroutine(FadeInCoroutine(stepPerFrame));
    }

    //Fades a UIElement in
    IEnumerator FadeInCoroutine(float stepPerFrame)
    {
        while (cg.alpha < 1)
        {
            cg.alpha += stepPerFrame;

            if (cg.alpha >= 1 - stepPerFrame && cg.alpha != 1)
            {
                cg.alpha = 1;
                break;
            }
            FadeOut(stepPerFrame);
            yield return null;
        }

        cg.interactable = true;

        //RaiseFadeInComplete();

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
        //bullet.GetComponent<BoxCollider>().enabled = true;

        StartCoroutine(FadeOutCoroutine(stepPerFrame));
    }

    //Fades a UIElement out
    IEnumerator FadeOutCoroutine(float stepPerFrame)
    {
        while (cg.alpha > 0)
        {
            cg.alpha -= stepPerFrame;

            if (cg.alpha <= stepPerFrame
                && cg.alpha != 0)
            {
                cg.alpha = 0;
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
