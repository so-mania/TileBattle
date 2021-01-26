using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public bool isPlaying { get; private set; } = false;

    //プレイヤーが準備完了か
    public bool readyPlayer1 { private get; set; } = false;
    public bool readyPlayer2 { private get; set; } = false;


    [SerializeField]
    Text countTxt;
    float startCount = 3;

    [SerializeField]
    Text TimeText;
    [SerializeField]
    float playTime = 30;

    void Update()
    {
        // カウントダウン
        if(!isPlaying && readyPlayer1 && readyPlayer2)
        {
            if (!countTxt.enabled) countTxt.enabled = true;

            startCount -= Time.deltaTime;
            countTxt.text = string.Format("{0}", (int)startCount + 1);

            // 開始
            if(startCount <= 0)
            {
                countTxt.enabled = false;
                isPlaying = true;
                TimeText.enabled = true;
            }
        }

        if (isPlaying)
        {
            playTime -= Time.deltaTime;
            TimeText.text = string.Format("{0}", (int)playTime);

            // 終了
            if (playTime <= 0)
            {
                TimeText.enabled = false;
                isPlaying = false;
                Judge();
            }
        }

    }

    private void Judge()
    {
        var Reds = GameObject.FindGameObjectsWithTag("Red");
        var Blues = GameObject.FindGameObjectsWithTag("Blue");

        if (Reds.Length > Blues.Length)
        {
            countTxt.text = "Player1 Win";
            countTxt.enabled = true;
        }
        else if (Blues.Length > Reds.Length)
        {
            countTxt.text = "Player2 Win";
            countTxt.enabled = true;
        }
        else
        {
            countTxt.text = "Draw";
            countTxt.enabled = true;
        }
    }
}
