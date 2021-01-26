using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            }
        }

        if (isPlaying)
        {
            playTime -= Time.deltaTime;
            TimeText.text = string.Format("{0}", (int)playTime);
        }

        //ゲーム終了
        if (playTime <= 0)
        {
            TimeText.enabled = false;

        }
    }
}
