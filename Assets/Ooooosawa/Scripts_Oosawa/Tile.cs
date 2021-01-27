using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Tile : MonoBehaviourPunCallbacks
{
    PunTest pTest;
    Color myColor;

    private void Awake()
    {
        ColorSerializer.Register();
        pTest = GameObject.Find("PUNPUNPUN").GetComponent<PunTest>();
        myColor = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider col)
    {
        var color = col.GetComponent<PlayerCore>().myColor;
        if (this.myColor != color && pTest.ServerFlg)
        {
            photonView.RPC("ChangeMyColor", RpcTarget.All, color);
            ChangeMyColor(color);
        }
    }

    [PunRPC]
    void ChangeMyColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
        this.myColor = color;

        if (this.myColor == Color.red)
            transform.parent.tag = "Red";
        else if (this.myColor == Color.blue)
            transform.parent.tag = "Blue";
    }
}
