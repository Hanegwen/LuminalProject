using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    TextMeshPro WallText;

    [SerializeField]
    TextMeshPro FinalScoreText;

    float currentscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UpdateScore(1f);
        }
    }

    public void UpdateScore(float ScoreToAdd)
    {
        currentscore += ScoreToAdd;

        WallText.text = currentscore.ToString();
    }
}
