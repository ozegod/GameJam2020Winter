using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameObject Dice;
    private DiceController diceController;
    private TurnManager turnManager;
    [SerializeField]
    // 現在自分のターンかどうか
    private bool myTurn;

    public int d = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ターンマネジャーを取得
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        this.Dice = GameObject.Find("Dice");
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
            d = int.Parse(this.Dice.GetComponent<Text>().text);
            int currentPlayer = TurnManager.currentPlayer;
            PlayerMovement(d, currentPlayer);
                
        }
    }

    public void SetMyTurn(bool flag)
    {
        myTurn = flag;
    }

    void PlayerMovement(int d, int n)
    {
        float angleTheta = 0;
        float anglePhi = 0;

        if (n == 0)
        {
            angleTheta = Player1Data.angleTheta;
            anglePhi = Player1Data.anglePhi;
        }
        else
        {
            angleTheta = Player2Data.angleTheta;
            anglePhi = Player2Data.anglePhi;
        }

        int step = 0;
        int currentPlayer = TurnManager.currentPlayer;

        while (step < d)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anglePhi += 30f;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anglePhi -= 30f;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                angleTheta += 30;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                angleTheta -= 30;
            }
            PlayerPosition(angleTheta, anglePhi, n);
            
        }

    }

    void PlayerPosition(float angleTheta, float anglePhi, int n)
    {
        if (n == 0)
        {
            _ = Player1Data.angleTheta == angleTheta;
            _ = Player1Data.anglePhi == anglePhi;
        }
        else
        {
            _ = Player2Data.angleTheta == angleTheta;
            _ = Player2Data.anglePhi == anglePhi;
        }
    }
}
