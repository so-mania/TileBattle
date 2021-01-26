﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    public GameObject PunPunPun; //メインスクリプト
    public GameObject inputField; //IPアドレスの入力欄
    public GameObject toggle;     //サーバーのチェックボックス

    public void OnClick()
    {
        //IPアドレスの取得
        string ip = inputField.GetComponent<InputField>().text;
        //サーバーのチェック
        bool server = toggle.GetComponent<Toggle>().isOn;
        //ログイン処理を呼び出す
        PunPunPun.GetComponent<PunTest>().Login(ip, server);
        //親オブジェクトを非表示(Panelを非表示)
        transform.parent.gameObject.SetActive(false);
    }
}
