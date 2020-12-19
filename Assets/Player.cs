using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private DiceController diceController;
    private TurnManager turnManager;
    [SerializeField]
    private Text outputText;
    // 現在自分のターンかどうか
    private bool myTurn;

    int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ターンマネジャーを取得
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 自分のターンでなければなにもしない
        if (!myTurn)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            diceController.DiceRoll();
        }
    }

    public void SetMyTurn(bool flag)
    {
        myTurn = flag;
    }
}
