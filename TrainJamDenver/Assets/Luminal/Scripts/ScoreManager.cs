using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    List<TextMeshPro> WallText;

    [SerializeField]
    TextMeshPro FinalScoreText;

    float currentscore;

    [SerializeField]
    List<Vector3> ScoreTextTransform = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (TextMeshPro text in WallText)
        {
            ScoreTextTransform.Add(text.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UpdateScore(10f);
        }

        
    }

    public void UpdateScore(float ScoreToAdd)
    {
        currentscore += ScoreToAdd;
        foreach (TextMeshPro wall in WallText)
        {
            wall.text = currentscore.ToString();
            wall.GetComponent<Animator>().Play("ScoreTextIncrease");
        }
    }
}
