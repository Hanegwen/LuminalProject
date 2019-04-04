using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CountdownSystem : MonoBehaviour
{
    bool endofGame;
    [SerializeField] TextMeshPro Countdown;
    NodeObjSpawning NodeObj;
    [SerializeField]
    TextMeshPro FunText;

    [SerializeField]
    TextMeshPro ScoreText;
    float timer = 35;
    float playerScore = 0;
    CoreyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        NodeObj = FindObjectOfType<NodeObjSpawning>();
        playerScore = -1000f;
        ScoreText.text = "Score: " + playerScore;
        manager = FindObjectOfType<CoreyManager>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        Countdown.text = Mathf.RoundToInt(timer).ToString();

        if (timer >= 33)
        {
            FunText.text = "Welcome To One Wild Ride";
        }
        else if (timer >= 27)
        {
            FunText.text = "Swipe Right to Move Right and Swipe Left to Move Left";
        }
        else if (timer >= 23)
        {
            FunText.text = "Avoid The Obstacles falling";
        }
        else if (timer >= 18)
        {
            FunText.text = "Created by: Corey King & Mike Morrone";

        }
        else if (timer >= 10)
        {
            FunText.text = "Audio By: Ali Cedroni";

        }
        else if (timer >= 5)
        {
            FunText.text = "Future Updates Coming Soon, Follow us on Twitter:" +
                " @TwitchHat, @Mikey_Morrone";
        }

        if (timer <= 0)
        {
            manager.gameHasBegun = true;
            FunText.enabled = false;
            Countdown.enabled = false;
            NodeObj.GameHasStarted = true;
        }



    }

    public void UpdateScoreText(float score)
    {
        playerScore += score;
        ScoreText.text = "Score: " + playerScore;

    }
    //MenuSysten Win/Lose State  ** Quick Fade to Black Screen** Display Win or Loss.  Retry or Take off Headset
    //Credits
    //Particles
}


