using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    // 全プレイヤー
    [SerializeField]
    private Player[] player;

    // 現在のプレイヤー番号
    public static int currentPlayer;


    // Start is called before the first frame update
    void Start()
    {
        // 最初のプレイヤーの設定
        player[0].SetMyTurn(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 次のプレイヤーに変更
    public void CoutnUp()
    {
        // 現在のプレイヤーのturnフラグをオフにする
        player[currentPlayer].SetMyTurn(false);
        // 次のプレイヤー番号にする
        currentPlayer++;
        // 最後のプレイヤーであれば最初のプレイヤーに戻す
        if (currentPlayer >= player.Length)
        {
            currentPlayer = 0;
        }
        // 現在のプレイヤーのターンにする
        player[currentPlayer].SetMyTurn(true);
    }
}
