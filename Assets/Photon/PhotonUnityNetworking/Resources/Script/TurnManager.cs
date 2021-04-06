using System; // 注意
using System.Collections;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;　//注意
public class  TurnManager : UIBehaviour, IPunTurnManagerCallbacks// このコールバックを使用する際は1，2，3，4，5を実装しなければならない
{
    private PhotonView PhotonView;//追加する
    private Text WaitingText;//待ってくださいのテキスト
    private PunTurnManager turnManager;

#pragma warning disable CS0114 // メンバーは継承されたメンバーを非表示にします。override キーワードがありません
    public void Awake()// StartをAwakeにする。
#pragma warning restore CS0114 // メンバーは継承されたメンバーを非表示にします。override キーワードがありません
    {
        this.turnManager = this.gameObject.AddComponent<PunTurnManager>();//PunTurnManagerをコンポーネントに追加
        this.turnManager.TurnManagerListener = this;//リスナーを？
        this.turnManager.TurnDuration = int.MaxValue;
    }
    void Update()
    {
        if (this.turnManager.IsCompletedByAll) //両方のプレイヤーがターンを終了しているか
        {
            //後に処理を書く予定
        }

    }
    public void OnPlayerFinished(Player photonPlayer, int turn, object move){}
    public void OnPlayerMove(Player photonPlayer, int turn, object move){}
    public void OnTurnBegins(int turn){}

    public void OnTurnCompleted(int obj)//4ターン終了時に呼ばれるメソッド　（あなたのターン開始・終了みたいな文字を出す）
    {
        Debug.Log("OnTurnCompleted: " + obj);
        this.OnEndTurn();//エンドターンに必要な処理をします
        this.StartTurn();
    }
    public void OnTurnTimeEnds(int turn)//5　タイマーが終了した場合
    {
        this.StartTurn();
    }
    public void StartTurn()//ターン開始メソッド（シーン開始時にRPCから呼ばれる呼ばれるようにしてあります。）
    {
        if (PhotonNetwork.IsMasterClient)
        {
            this.turnManager.BeginTurn();//turnmanagerに新しいターンを始めさせる
            PhotonView.RPC("RPC_AutomaticSend", RpcTarget.All);
        }
    }
    public void MakeTurn(int index)//手を決めるメソッド
    {
        this.turnManager.SendMove(index, true);//アクションを送るときに呼ぶ（アクション,ターンを終了するかどうか(true)）
    }
    public void OnClickButton()
    {
        int index = 9;
        this.MakeTurn(index);
        Debug.Log(PhotonView.OwnerActorNr);
    }
    public void OnEndTurn()//エンドターンのメソッド
    {
        //ターンエンドで必要な処理を書く予定
    }
    [PunRPC]
    public void RPC_AutomaticSend()
    {
        if ((this.turnManager.Turn % 2) + 1 == PhotonView.OwnerActorNr)
        {
            int index = 0;
            this.turnManager.SendMove(index, true);
            this.WaitingText.text = "wait for another player...";
        }
        else
        {
            this.WaitingText.text = "";
        }
    }
}