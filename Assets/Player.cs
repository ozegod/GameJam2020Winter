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
    private Text outputText;
    // 現在自分のターンかどうか
    private bool myTurn;

    public Vector3 Player_pos_possible;
    int d = 0;

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
            PlayerMovement(d);
        
        //Playerが行ける場所の計算
            Transform Player_pos = this.transform;
        float x = Player_pos.x;
        float y = Player_pos.y;
        float z = Player_pos.z;
        int a ;
        int b ;
        while(diceController.d >= Mathf.abs(a))
        {
        Mathf.abs(b) = diceController.d - a;
        Theta1 = a * 30 * Mathf.Deg2Rad;
        Phi1 = b * 30 * Mathf.Deg2Rad;
        Player_pos_possible.x = x + r * Mathf.Sin(Theta1) * Math.Cos(Phi1);
        Player_pos_possible.y = y + r * Mathf.Sin(Theta1);
        Player_pos_possible.z = z + r * Mathf.Sin(Theta1) * Mathf.Sin(Phi1);
        Player_pos_possible = Vector3 (Player_pos_possible.x, Player_pos_possible.y, Player_pos_possible.z);
        }
    }

    public void SetMyTurn(bool flag)
    {
        myTurn = flag;
    }

    void PlayerMovement(int d)
    {
        int step = 0;
        int x0 = (int)PlayerData.x;
        int y0 = (int)PlayerData.y;

        while (step < d)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PlayerData.x += 1;
                if (PlayerData.x >= 12)
                {
                    PlayerData.x -= 12;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PlayerData.x -= 1;
                if (PlayerData.x < 0)
                {
                    PlayerData.x += 12;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayerData.y += 1;
                if (PlayerData.y >= 12)
                {
                    PlayerData.y -= 12;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayerData.y -= 1;
                if (PlayerData.y < 12)
                {
                    PlayerData.y += 12;
                }
            }

            step = Mathf.Abs(x0 - (int)PlayerData.x + y0 - (int)PlayerData.y);
        }
        
    }
    }
}
