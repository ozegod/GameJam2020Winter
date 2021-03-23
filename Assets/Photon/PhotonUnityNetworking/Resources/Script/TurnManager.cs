using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class TurnManager : MonoBehaviourPunCallbacks, IPunTurnManagerCallbacks
{
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

    // プレイヤーがターン終了したとき
    public void OnPlayerFinished(Player photonPlayer, int turn, object move) { }

    // 動作したとき
    public void OnPlayerMove(Player photonPlayer, int turn, object move) { }

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

    // タイマー終了
    public void OnTurnTimeEnds(int turn) { }

    // 攻撃ターンを終了させる
    // 「こうげき」ボタンをクリックしたときに呼びます。
    public void AttackTurnEnd()
    {
        this.turnManager.SendMove(1, true);
    }

    public void OnPlayerMove(Photon.Realtime.Player player, int turn, object move)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerFinished(Photon.Realtime.Player player, int turn, object move)
    {
        throw new System.NotImplementedException();
    }
}