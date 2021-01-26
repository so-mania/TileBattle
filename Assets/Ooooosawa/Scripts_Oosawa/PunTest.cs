using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PunTest : MonoBehaviourPunCallbacks
{
    public bool ServerFlg; //サーバーフラグ

    [SerializeField]
    GameObject tileParent;

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
        var v = new Vector3(Random.Range(1f, 9f), 0, Random.Range(1f, 9f));
        
        //参加
        if (ServerFlg)
        {
            GameObject go = PhotonNetwork.Instantiate("Player1", v, Quaternion.identity);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject Tile = PhotonNetwork.Instantiate("Tile_test", new Vector3(j, 0.02f, i), Quaternion.Euler(90,0,0));
                    Tile.transform.parent = tileParent.transform;
                }
            }
        }
        else
        {
            GameObject go = PhotonNetwork.Instantiate("Player2", v, Quaternion.identity);
        }

    }
}
