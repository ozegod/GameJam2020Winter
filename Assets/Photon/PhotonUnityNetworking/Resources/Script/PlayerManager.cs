using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using Photon.Pun;
using Photon.Realtime;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    //頭上のUIのPrefab
    public GameObject PlayerUiPrefab;

    //現在のmoney
    public int money = 0;

    //Localのプレイヤーを設定
    public static Player LocalPlayerInstance;

    #region プレイヤー初期設定
    void Awake()
    {
        if (photonView.IsMine)
        {
            LocalPlayerInstance = PhotonNetwork.LocalPlayer;
        }
    }
    #endregion

    #region 頭上UIの生成
    void Start()
    {
        PlayerUiPrefab.GetComponent<PlayerUIScript>().SetTarget(this);
    }
    #endregion

    void Update()
    {
        if (!photonView.IsMine) //このオブジェクトがLocalでなければ実行しない
        {
            return;
        }
        //CLocalVariablesを参照し、現在のHPを更新
        money = GamePlayerProperty.GetMoney(LocalPlayerInstance);
    }

    #region OnPhotonSerializeView同期
    //プレイヤーのmoneyを同期
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.money);
        }
        else
        {
            this.money = (int)stream.ReceiveNext();
        }
    }
    #endregion
}