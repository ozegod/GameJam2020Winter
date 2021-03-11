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

    public static int D = 0;
    public int h = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ターンマネジャーを取得
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        this.Dice = GameObject.Find("Dice");
    
    }

    // Update is called once per frame
    void Update()
    {
            
        if (!myTurn)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                diceController.a++;
                //if (diceController.a % 6 == 2)
                {
                    //diceController.a++;
                }

                diceController.DiceRoll();
            }

            D = int.Parse(this.Dice.GetComponent<Text>().text);
            if (diceController.a % 3 == 2)
            {
                if (D > 0)
                {
                    D = int.Parse(this.Dice.GetComponent<Text>().text);
                    Playermove.MoveStart();
                }
                else
                {
                    Playermove.MoveStop();
                }             
            }

            if ((diceController.a % 3 == 0) && (diceController.a > 0))
            {
                turnManager.CountUp();
                //Playermove.u = 0;
            }
        //}
        }

        //スペースキー押された回数をとりあえずカウント
        if (Input.GetKeyDown(KeyCode.Space))
        {
            h++;
        }
    }

    public void SetMyTurn(bool flag)
    {
        myTurn = flag;
    }


}
