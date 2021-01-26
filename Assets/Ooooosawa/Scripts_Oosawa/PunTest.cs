using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PunTest : MonoBehaviourPunCallbacks
{
    public bool ServerFlg; //サーバーフラグ
    public void Login(string ip, bool sf)
    {
        //サーバーフラグの設定
        ServerFlg = sf;
        //IPアドレスの設定
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip;
        //ポート番号の設定
        PhotonNetwork.PhotonServerSettings.AppSettings.Port = 5055;
        //ネットワークへの接続
        PhotonNetwork.ConnectUsingSettings();
    }

    // サーバーへの接続が成功した時
    public override void OnConnectedToMaster()
    {
        //ルームが無ければ作成してからルーム参加する
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    // ルームに入ったとき時
    public override void OnJoinedRoom()
    {
        // ランダムな位置にネットワークオブジェクトを生成する
        var v = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
        
        //参加
        if (ServerFlg)
        {
            GameObject go = PhotonNetwork.Instantiate("Player1", v, Quaternion.identity);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject Tile = PhotonNetwork.Instantiate("Tile", new Vector3(j, 0.01f, i), Quaternion.identity);
                }
            }
        }
        else
        {
            GameObject go = PhotonNetwork.Instantiate("Player2", v, Quaternion.identity);
        }

    }
}
