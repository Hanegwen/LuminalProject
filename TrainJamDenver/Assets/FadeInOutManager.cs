using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerManager))]
public class FadeInOutManager : MonoBehaviour
{
    [Tooltip("Must have a NodePlaneTeleportation Component.")]
    public GameObject Player;

    [Tooltip("Must have a FadeUIElement Componenet.")]
    public GameObject UIElementToFade;

    FadeUIElement fUIe;
    TimerManager tm;
    NodePlaneTeleportation npt;

    // Start is called before the first frame update
    void Start()
    {
        tm = this.GetComponent<TimerManager>();
        //fUIe = UIElementToFade.GetComponent<FadeUIElement>();
        npt = Player.GetComponent<NodePlaneTeleportation>();

        tm.TimerRunDown += OnTimerRunDown;

        //fUIe.FadeInComplete += OnFadeInComplete;
        //fUIe.FadeOutComplete += OnFadeOutComplete;
    }

    private void OnFadeOutComplete(object source, EventArgs e)
    {

    }

    private void OnFadeInComplete(object source, EventArgs e)
    {
        npt.TeleportToNextNode();
        fUIe.FadeOut(0.005f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTimerRunDown(object sender, EventArgs e)
    {
        fUIe.FadeIn(0.005f);
    }

    void OnDestroy()
    {
        tm.TimerRunDown -= OnTimerRunDown;

        fUIe.FadeInComplete -= OnFadeInComplete;
        fUIe.FadeOutComplete -= OnFadeOutComplete;
    }
}
