using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
    public PlayerData player;
    int playerid;
    private PunTurnManager turnManager;

    public void Awake()
    {
        this.turnManager = this.gameObject.AddComponent<PunTurnManager>();
        this.turnManager.TurnManagerListener = this;
        this.turnManager.TurnDuration = int.MaxValue;
    }

    private void Start()
    {
        // ここで最初のターンを開始させている。
        if (PhotonNetwork.IsMasterClient)
        {
            this.turnManager.BeginTurn();
        }
    }

    // ターン開始
    public void OnTurnBegins(int turn)
    {
        // ここで、「こうげき」ボタンもしくは待機中だよな文言を表示しています。
    }

    // 全プレイヤーがターン終了
    public void OnTurnCompleted(int obj)
    {
        // ここで、今表示させている「こうげき」ボタンなどを破棄しつつ、次のターンを開始させます。
        if (PhotonNetwork.IsMasterClient)
        {
            this.turnManager.BeginTurn();
        }
    }

    // 攻撃ターンを終了させる
    // 「こうげき」ボタンをクリックしたときに呼びます。
    public void AttackTurnEnd()
    {
        this.turnManager.SendMove(1, true);
    }

    public void OnPlayerMove(Player player, int turn, object move)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerFinished(Player player, int turn, object move)
    {
        throw new System.NotImplementedException();
    }

    public void OnTurnTimeEnds(int turn)
    {
        throw new System.NotImplementedException();
    }
}