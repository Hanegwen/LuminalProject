﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//[RequireComponent(typeof(CanvasGroup))]
public class FadeUIElement : MonoBehaviour
{
    //[Tooltip("UI Element must have a Canvas Group")]
    //public Behaviour UIElement;       //Must have a CanvasGroup

    public delegate void FadeEventHandler(object source, EventArgs e);

    public event FadeEventHandler FadeOutComplete;
    public event FadeEventHandler FadeInComplete;

    [SerializeField]
    Material black;

    private CanvasGroup cg;
    public NodePlaneTeleportation npt;

    Renderer rend;

    Bullet bullet;

    int x = 0;
    int y = 0;
    int z = 0;

    float opac = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        bullet = FindObjectOfType<Bullet>();

        //npt = FindObjectOfType<NodePlaneTeleportation>();
        //npt = npt.GetComponent<NodePlaneTeleportation>();

        rend.material = black;
        rend.material.SetColor("Black", new Vector4(x,y,z,opac));
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
        //rend.material.SetColor("_Color", new Vector4(x, y, z, opac));
        //if (npt == null)
        //{
        //    npt = FindObjectOfType<NodePlaneTeleportation>();
        //}
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

        //rend.interactable = true;

        //RaiseFadeInComplete();

        npt.TeleportToNextNode();

        FadeOut(stepPerFrame);

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
            //Debug.Log(cg.alpha);


            if (cg.alpha <= stepPerFrame
                && cg.alpha != 0)
            {
                cg.alpha = 0;
                //Debug.Log("hit!");
                break;
            }

            yield return null;
        }
        //rend.interactable = false;

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
