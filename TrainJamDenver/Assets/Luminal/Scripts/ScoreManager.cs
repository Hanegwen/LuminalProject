using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    List<TextMeshPro> WallText;

    [SerializeField]
    TextMeshPro FinalScoreText;

    float currentscore;

    [SerializeField]
    float MoveText = 2;

    [SerializeField]
    float jumpPower = 1;

    [SerializeField]
    int numJumps = 2;

    [SerializeField]
    float duration = 6;

    [SerializeField]
    float DelayForReversal = 2;

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
        int position = 0;
        currentscore += ScoreToAdd;
        foreach (TextMeshPro wall in WallText)
        {
            //Vector3 baseLocation = wall.transform.position;

            //wall.transform.DOJump(new Vector3(wall.transform.localPosition.x - MoveText, wall.transform.localPosition.y, wall.transform.localPosition.z - MoveText), jumpPower, numJumps, duration);
            //wall.animator.setbool
            wall.text = currentscore.ToString();
            wall.GetComponent<Animator>().Play("ScoreTextIncrease");// SetBool("HasIncreased", true);

            //wall.transform.DOJump(ScoreTextTransform[position], jumpPower, numJumps, duration).SetDelay(DelayForReversal);
            //position++;
        }
    }
}
